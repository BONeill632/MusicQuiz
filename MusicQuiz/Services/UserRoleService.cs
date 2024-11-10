using Microsoft.AspNetCore.Identity;

namespace MusicQuiz.Services
{
    public class UserRoleService
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserRoleService(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task AssignRoleToUserAsync(string userEmail, string roleName)
        {
            var user = await _userManager.FindByEmailAsync(userEmail);
            if (user != null && !await _userManager.IsInRoleAsync(user, roleName))
            {
                await _userManager.AddToRoleAsync(user, roleName);
            }
        }
    }
}
