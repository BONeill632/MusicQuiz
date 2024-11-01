using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Enums;
using MusicQuiz.Extensions;
using MusicQuiz.Models;
using System.Diagnostics;

namespace MusicQuiz.Controllers
{
    public class QuizController : Controller
    {
        /// <summary>
        /// Index action method for the Quiz
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var quiz = new MusicQuizViewModel();
            return View(quiz);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="selectedTopic"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectDifficulty(string selectedTopic)
        {
            // Store the selected topic in TempData
            TempData["SelectedTopic"] = selectedTopic;
            return RedirectToAction("SelectDifficulty");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectDifficulty(MusicQuizViewModel model, string selectedTopic)
        {
            // Retrieve the selected topic from TempData
            if (TempData["SelectedTopic"] != null)
            {
                model.SelectedTopic = TempData["SelectedTopic"].ToString();
            }

            return View(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Start(MusicQuizViewModel model)
        {
            // Showing the selected topic and difficulty
            var newModel = new MusicQuizViewModel
            {
                SelectedTopic = model.SelectedTopic,
                SelectedDifficulty = model.SelectedDifficulty,

                // Load the quiz data based on the selected topic and difficulty
                Question = "Identify the correct frequency",
                //MusicQuestionFilePath = $"~/Music/{model.SelectedTopic}/1.25kHz.wav",
                MusicQuestionFilePath = "/Music/SineWave/1.25kHz.wav",
                Options = new List<string> { "1.25kHz", "800Hz", "1.5kHz", "2kHz" },
                CorrectAnswer = "1.25kHz",
            };

            return View(newModel);
        }

        public IActionResult SubmitAnswer(string selectedOption, string correctAnswer)
        {
            bool isCorrect = selectedOption == correctAnswer;
            ViewBag.IsCorrect = isCorrect;
            return View("Result");
        }
    }
}
