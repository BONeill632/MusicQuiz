using Microsoft.AspNetCore.Mvc;

namespace MusicQuiz.Controllers
{
    public class LeaderboardsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
