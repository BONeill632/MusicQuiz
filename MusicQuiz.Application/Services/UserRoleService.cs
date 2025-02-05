using Microsoft.AspNetCore.Identity;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Services
{
    public class UserRoleService(UserManager<UserData> userManager)
    {
        /// <summary>
        /// User manager
        /// </summary>
        /// <param name="userEmail"></param>
        /// <param name="roleName"></param>
        /// <returns></returns>
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
