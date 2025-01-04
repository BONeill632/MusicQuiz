using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;
using MusicQuiz.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicQuiz.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager) : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var users = await userManager.Users.ToListAsync();
#pragma warning disable CS8601 // Possible null reference assignment.
            var userListViewModel = users.Select(user => new UserListViewModel
            {
                UserName = user.UserName,
                UserId = user.Id,
                Email = user.Email
            }).ToList();
#pragma warning restore CS8601 // Possible null reference assignment.

            return View(userListViewModel);
        }

        public async Task<IActionResult> Manage(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

#pragma warning disable CS8601 // Possible null reference assignment.
            var model = new ManageUserRolesViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StudentID = user.StudentID,
                Roles = await roleManager.Roles.ToListAsync(),
                UserRoles = await userManager.GetRolesAsync(user),
                SelectedRole = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "User"
            };
#pragma warning restore CS8601 // Possible null reference assignment.

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(ManageUserRolesViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await userManager.GetRolesAsync(user);
            var selectedRole = model.SelectedRole;

            if (!userRoles.Contains(selectedRole))
            {
                var result = await userManager.AddToRoleAsync(user, selectedRole);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to add role");
                    return View(model);
                }

                result = await userManager.RemoveFromRolesAsync(user, userRoles.Except([selectedRole]));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to remove roles");
                    return View(model);
                }
            }

            return RedirectToAction("UserList");
        }
    }
}
