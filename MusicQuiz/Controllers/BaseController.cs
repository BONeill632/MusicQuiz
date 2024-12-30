using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MusicQuiz.Web.Models;

public class BaseController : Controller
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        if (context.Controller is Controller controller && controller.ViewData.Model is BaseViewModel model)
        {
            model.IsLoggedIn = User.Identity.IsAuthenticated;
            model.UserId = User.Identity.IsAuthenticated ? User.Identity.Name : null;
        }
    }
}
