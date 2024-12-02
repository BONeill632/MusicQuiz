using Microsoft.AspNetCore.Identity;

namespace MusicQuiz.Application.Services
{
    public class UserRoleService(UserManager<IdentityUser> userManager)
    {
        public async Task AssignRoleToUserAsync(string userEmail, string roleName)
        {
            var user = await userManager.FindByEmailAsync(userEmail);
            if (user != null && !await userManager.IsInRoleAsync(user, roleName))
            {
                await userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
