using Microsoft.AspNetCore.Mvc;

namespace MusicQuiz.Controllers
{
    public class AssessmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
