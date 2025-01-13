using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicQuiz.Web.Models;

namespace MusicQuiz.Web.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (context.Controller is Controller controller && controller.ViewData.Model is BaseViewModel model)
            {
                var isAuthenticated = User?.Identity?.IsAuthenticated ?? false;
                model.IsLoggedIn = isAuthenticated;
                model.UserId = isAuthenticated ? User?.Identity?.Name ?? string.Empty : string.Empty;
            }
        }
    }
}