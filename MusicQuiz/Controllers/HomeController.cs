using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Models;
using MusicQuiz.Web.Models;
using System.Diagnostics;

namespace MusicQuiz.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public ILogger<HomeController> Logger { get; } = logger;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}