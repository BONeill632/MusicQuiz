using Microsoft.AspNetCore.Mvc;

namespace MusicQuiz.Web.Controllers
{
    public class AssessmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
