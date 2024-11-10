using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Services;

public class AccountController : Controller
{
    private readonly UserRoleService _userRoleService;

    public AccountController(UserRoleService userRoleService)
    {
        _userRoleService = userRoleService;
    }

    public async Task<IActionResult> AssignRole(string userEmail, string roleName)
    {
        await _userRoleService.AssignRoleToUserAsync(userEmail, roleName);
        return RedirectToAction("Index");
    }
}
