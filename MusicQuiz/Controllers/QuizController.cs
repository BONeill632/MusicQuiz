using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Enums;
using MusicQuiz.Models;
using System.Diagnostics;

namespace MusicQuiz.Controllers
{
    public class QuizController : Controller
    {

        [HttpPost]
        public IActionResult NextPage(string selectedDifficulty)
        {
            // Parse the selected difficulty
            if (Enum.TryParse<DifficultyLevel>(selectedDifficulty, true, out var difficulty))
            {
                // Pass the selected difficulty to the next page
                // You can use TempData, ViewData, or a ViewModel to pass the data
                TempData["SelectedDifficulty"] = difficulty;
                return RedirectToAction("NextPage");
            }

            // Handle invalid selection
            return RedirectToAction("Index");
        }

        public IActionResult NextPage()
        {
            // Retrieve the selected difficulty from TempData
            var selectedDifficulty = TempData["SelectedDifficulty"];
            return View(selectedDifficulty);
        }


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