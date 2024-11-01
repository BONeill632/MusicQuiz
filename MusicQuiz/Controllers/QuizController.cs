using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Models;
using System.Diagnostics;

namespace MusicQuiz.Controllers
{
    public class QuizController : Controller
    {
        /// <summary>
        /// Index action method
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var quiz = new MusicQuizViewModel
            {
                Question = "Identify the song",
                MusicQuestionFilePath = Url.Content("~/Music/song.mp3"),
                Options = new List<string> { "Song A", "Song B", "Song C", "Song D" },
                CorrectAnswer = "Song A"
            };
            return View(quiz);
        }


        /// <summary>
        /// Check if answer is correct
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        public IActionResult Result(string answer)
        {
            var quiz = new MusicQuizViewModel
            {
                Question = "Identify the song",
                MusicQuestionFilePath = Url.Content("~/Music/Cornet A.wav"),
                Options = new List<string> { "Song A", "Song B", "Song C", "Song D" },
                CorrectAnswer = "Song A"
            };

            if (answer == quiz.CorrectAnswer)
            {
                ViewBag.Result = "Correct!";
            }
            else
            {
                ViewBag.Result = "Incorrect!";
            }

            return View(quiz);
        }
    }
}