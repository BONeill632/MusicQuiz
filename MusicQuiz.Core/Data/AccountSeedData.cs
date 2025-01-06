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
                adminUser = new UserData { UserName = adminEmail, Email = adminEmail, FirstName = "Admin", LastName = "User", StudentID = "0", IntID = 1};
                var result = await userManager.CreateAsync(adminUser, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }

            // "NotLoggedIn" user creation
            var notLoggedInUser = await userManager.FindByEmailAsync(notLoggedInEmail);
            if (notLoggedInUser == null)
            {
                notLoggedInUser = new UserData
                {
                    IntID = 0,
                    UserName = notLoggedInEmail,
                    Email = notLoggedInEmail,
                    FirstName = "NotLoggedIn",
                    LastName = "NotLoggedIn",
                    StudentID = "0",
                    LockoutEnabled = true, // Enable lockout
                    LockoutEnd = DateTimeOffset.MinValue // Set lockout time to now, locked out indefinitely. Account is only used for reference purposes
                };

                var result = await userManager.CreateAsync(notLoggedInUser, notLoggedInPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(notLoggedInUser, "User");
                }
            }
        }
    }
}
