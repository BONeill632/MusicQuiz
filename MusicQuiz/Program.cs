using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Application.Services;
using Microsoft.Build.Locator;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Data;

var builder = WebApplication.CreateBuilder(args);

// Determine the environment
var environment = builder.Environment;

string msbuildPath = string.Empty;

// Use default MSBuild paths based on environment if the variable is not set
if (environment.IsDevelopment())
{
    msbuildPath = @"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe";
}

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// Add session services
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register ApplicationDbContext with environment-specific connection string
string? connectionString;

    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string not found.");
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 21))));

// Add Identity services with roles
builder.Services.AddDefaultIdentity<UserData>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 6;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

// Configure application cookie
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";
    options.LogoutPath = "/Identity/Account/Logout";
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";
});

// Register UserRoleService
builder.Services.AddScoped<UserRoleService>();

// Register the ResultsService
builder.Services.AddScoped<IResultsService, ResultsService>();

// Register the UserExpService
builder.Services.AddScoped<UserExpService>();

var app = builder.Build();

await SeedData(app.Services);
await SeedAccountData(app.Services);


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// Enable session middleware
app.UseSession();

app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

// Initialize roles and seed data
await InitializeRoles(app.Services);

app.Run();

// Method to create roles
static async Task InitializeRoles(IServiceProvider serviceProvider)
{
    using var scope = serviceProvider.CreateScope();
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    string[] roleNames = ["Admin", "User"];
    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}

// Method to seed Question data
static async Task SeedData(IServiceProvider serviceProvider)
{
    try
    {
        using var scope = serviceProvider.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        Console.WriteLine("Seeding data...");

        if (!dbContext.QuizQuestions.Any())
        {
            var seedData = QuizQuestionSeedData.GenerateSeedData();
            await dbContext.QuizQuestions.AddRangeAsync(seedData);
            await dbContext.SaveChangesAsync();
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
    }
}

// Method to seed Account data
static async Task SeedAccountData(IServiceProvider serviceProvider)
{
    try
    {
        using var scope = serviceProvider.CreateScope();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UserData>>();
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        Console.WriteLine("Seeding account data...");

        await AccountSeedData.SeedUserData(userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred while seeding account data: {ex.Message}");
    }
}
