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
    public class AdminController : BaseController
    {
        private readonly UserManager<UserData> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var users = await _userManager.Users.ToListAsync();
            var userListViewModel = users.Select(user => new UserListViewModel
            {
                UserName = user.UserName,
                UserId = user.Id,
                Email = user.Email
            }).ToList();

            return View(userListViewModel);
        }

        public async Task<IActionResult> Manage(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var model = new ManageUserRolesViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                StudentID = user.StudentID,
                Roles = await _roleManager.Roles.ToListAsync(),
                UserRoles = await _userManager.GetRolesAsync(user),
                SelectedRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault() ?? "User"
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(ManageUserRolesViewModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var selectedRole = model.SelectedRole;

            if (!userRoles.Contains(selectedRole))
            {
                var result = await _userManager.AddToRoleAsync(user, selectedRole);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to add role");
                    return View(model);
                }

                result = await _userManager.RemoveFromRolesAsync(user, userRoles.Except(new[] { selectedRole }));

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