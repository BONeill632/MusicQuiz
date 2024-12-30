using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Application.Services;

namespace MusicQuiz.Web.Controllers
{
    public class AccountController(UserRoleService userRoleService) : BaseController
    {
        public async Task<IActionResult> AssignRole(string userEmail, string roleName)
        {
            await userRoleService.AssignRoleToUserAsync(userEmail, roleName);
            return RedirectToAction("Index");
        }
    }
}