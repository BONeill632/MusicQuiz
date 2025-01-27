using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Core.Data
{
    public static class AccountSeedData
    {
        /// <summary>
        /// Seeds the default admin and "NotLoggedIn" users.
        /// </summary>
        public static async Task SeedUserData(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager)
        {
            // Define the users and roles
            var adminEmail = "admin@admin.com";
            var adminPassword = "Admin@123";
            var notLoggedInEmail = "notloggedin@notloggedin.com";
            var notLoggedInPassword = "Password@123";

            // Ensure roles exist
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                adminRole = new IdentityRole("Admin");
                await roleManager.CreateAsync(adminRole);
            }

            var userRole = await roleManager.FindByNameAsync("User");
            if (userRole == null)
            {
                userRole = new IdentityRole("User");
                await roleManager.CreateAsync(userRole);
            }

            // Admin user creation
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new UserData { UserName = adminEmail, Email = adminEmail, FirstName = "Admin", LastName = "User", StudentID = "0", IntID = 1, AcademicYear = "00/01", LastLoggedIn = DateTime.Now };
                if ((await userManager.CreateAsync(adminUser, adminPassword)).Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // "NotLoggedIn" user creation
            var notLoggedInUser = await userManager.FindByEmailAsync(notLoggedInEmail);
            notLoggedInUser ??= new UserData
            {
                IntID = 0,
                UserName = notLoggedInEmail,
                Email = notLoggedInEmail,
                FirstName = "NotLoggedIn",
                LastName = "NotLoggedIn",
                StudentID = "0",
                LockoutEnabled = true,
                LockoutEnd = DateTimeOffset.MinValue,
                AcademicYear = "00/01",
                LastLoggedIn = DateTime.Now
            }; ;

            var result = await userManager.CreateAsync(notLoggedInUser, notLoggedInPassword);
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(notLoggedInUser, "User");
            }
        }
    }
}
