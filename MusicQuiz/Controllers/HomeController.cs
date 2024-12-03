using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Web.Models;
using System.Diagnostics;

namespace MusicQuiz.Web.Controllers
{
    public class HomeController(ILogger<HomeController> logger) : Controller
    {
        public ILogger<HomeController> Logger { get; } = logger;

        public IActionResult Index()
        {
            ClearQuizSession();

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

        /// <summary>
        /// Clear the quiz session
        /// </summary>
        private void ClearQuizSession()
        {
            HttpContext.Session.Remove("QuizQuestions");
            HttpContext.Session.Remove("CurrentQuestionIndex");
            HttpContext.Session.Remove("Score");
            HttpContext.Session.Remove("CorrectAnswers");
        }
    }
}