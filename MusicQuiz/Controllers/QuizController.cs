using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Models;
using System.Diagnostics;

namespace MusicQuiz.Controllers
{
    public class QuizController : Controller
    {
        public IActionResult Index()
        {
            var quiz = new MusicQuizViewModel
            {
                Question = "Identify the song",
                MusicFilePath = Url.Content("~/Content/Music/song.mp3"),
                Options = new List<string> { "Song A", "Song B", "Song C", "Song D" },
                CorrectAnswer = "Song A"
            };
            return View(quiz);
        }
    }
}