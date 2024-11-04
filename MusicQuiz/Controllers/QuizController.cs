using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Data;
using MusicQuiz.Enums;
using MusicQuiz.Extensions;
using MusicQuiz.Models;
using System.Diagnostics;

using System.Text.Json;

namespace MusicQuiz.Controllers
{
    public class QuizController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QuizController(ApplicationDbContext context)
        {
            _context = context;
        }

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
        /// Select music topic
        /// </summary>
        /// <param name="selectedTopic"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult SelectDifficulty(string selectedTopic)
        {
            if (string.IsNullOrEmpty(selectedTopic))
            {
                // Handle the case where selectedTopic is null or empty
                return BadRequest("Selected topic is required.");
            }

            // Store the selected topic in TempData
            TempData["SelectedTopic"] = selectedTopic;
            return RedirectToAction("SelectDifficulty");
        }

        /// <summary>
        /// Select difficulty
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SelectDifficulty(MusicQuizViewModel model)
        {
            // Retrieve the selected topic from TempData
            if (TempData["SelectedTopic"] != null)
            {
                var selectedTopicString = TempData["SelectedTopic"].ToString();
                if (!string.IsNullOrEmpty(selectedTopicString) && Enum.TryParse(typeof(Topic), selectedTopicString, out var selectedTopic))
                {
                    model.SelectedTopic = (Topic)selectedTopic;
                }
                else
                {
                    // Handle the case where the topic could not be parsed
                    return BadRequest("Invalid topic selected.");
                }
            }

            return View(model);
        }



        /// <summary>
        /// starting quiz
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Start(MusicQuizViewModel model)
        {
            if (model.SelectedTopic == default || model.SelectedDifficulty == default)
            {
                // Handle the case where selectedTopic or selectedDifficulty is null or empty
                return BadRequest("Selected topic and difficulty are required.");
            }

            // Load the quiz data based on the selected topic and difficulty
            var questions = _context.QuizQuestions
                .Where(q => q.TopicId == (int)model.SelectedTopic && q.DifficultyId == (int)model.SelectedDifficulty)
                .ToList();

            if (questions.Count == 0)
            {
                // Handle the case where no questions are found
                return View("NoQuestions");
            }

            // Select 10 random questions
            var random = new Random();
            var selectedQuestions = questions.OrderBy(q => random.Next()).Take(10).ToList();

            var questionViewModels = selectedQuestions.Select(q => new QuestionViewModel
            {
                SelectedTopic = model.SelectedTopic,
                SelectedDifficulty = model.SelectedDifficulty,
                Question = q.Question,
                MusicQuestionFilePath = q.QuestionMusicFilePath,
                Options = new List<string> { q.CorrectAnswer, q.WrongAnswerOne, q.WrongAnswerTwo, q.WrongAnswerThree },
                CorrectAnswer = q.CorrectAnswer,
            }).ToList();

            HttpContext.Session.SetString("QuizQuestions", JsonSerializer.Serialize(questionViewModels));
            HttpContext.Session.SetInt32("CurrentQuestionIndex", 0);

            return RedirectToAction("ShowQuestion");
        }

        /// <summary>
        /// Displays the current question.
        /// </summary>
        /// <returns></returns>
        /// <summary>
        public IActionResult ShowQuestion()
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : new List<QuestionViewModel>();
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;
            var answer = questions[currentIndex].UserAnswer;
            var scoreString = HttpContext.Session.GetString("Score");
            decimal score = 0;
            if (!string.IsNullOrEmpty(scoreString))
            {
                decimal.TryParse(scoreString, out score);
            }

            if (questions == null || !questions.Any())
            {
                return View("NoQuestions");
            }

            var model = questions[currentIndex];
            ViewBag.CurrentQuestionIndex = currentIndex;
            ViewBag.TotalQuestions = questions.Count;
            ViewBag.Score = score;
            ViewBag.userAnswer = answer;

            return View(model);
        }


        [HttpPost]
        public IActionResult NextQuestion(string selectedOption)
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : new List<QuestionViewModel>();
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;

            if (questions == null || !questions.Any())
            {
                return View("NoQuestions");
            }

            // Save the user's answer
            var currentQuestion = questions[currentIndex];
            var previousAnswer = currentQuestion.UserAnswer;
            currentQuestion.UserAnswer = selectedOption;

            var correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers") ?? 0;

            // Update the running total of correct answers
            if (currentQuestion.IsAnswered)
            {
                // If the question was previously answered, adjust the score based on the new answer
                if (previousAnswer == currentQuestion.CorrectAnswer && selectedOption != currentQuestion.CorrectAnswer)
                {
                    correctAnswers--;
                }
                else if (previousAnswer != currentQuestion.CorrectAnswer && selectedOption == currentQuestion.CorrectAnswer)
                {
                    correctAnswers++;
                }
            }
            else
            {
                // If the question was not previously answered, update the score based on the new answer
                if (selectedOption == currentQuestion.CorrectAnswer)
                {
                    correctAnswers++;
                }
                currentQuestion.IsAnswered = true;
            }

            HttpContext.Session.SetInt32("CorrectAnswers", correctAnswers);

            // Calculate the score
            decimal score = Math.Round((correctAnswers / (decimal)questions.Count) * 100, 2);
            HttpContext.Session.SetString("Score", score.ToString());

            HttpContext.Session.SetString("QuizQuestions", JsonSerializer.Serialize(questions));

            // Move to the next question
            currentIndex++;
            if (currentIndex >= questions.Count)
            {
                return RedirectToAction("QuizResults");
            }

            HttpContext.Session.SetInt32("CurrentQuestionIndex", currentIndex);

            return RedirectToAction("ShowQuestion");
        }


        /// <summary>
        /// Moves to the previous question.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PreviousQuestion()
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : new List<QuestionViewModel>();
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;

            if (questions == null || !questions.Any())
            {
                return View("NoQuestions");
            }

            // Move to the previous question
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = 0;
            }

            HttpContext.Session.SetInt32("CurrentQuestionIndex", currentIndex);

            return RedirectToAction("ShowQuestion");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IActionResult QuizResults()
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : new List<QuestionViewModel>();
            var correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers") ?? 0;
            var scoreString = HttpContext.Session.GetString("Score");
            decimal score = 0;
            if (!string.IsNullOrEmpty(scoreString))
            {
                decimal.TryParse(scoreString, out score);
            }

            var model = new QuizResultsViewModel
            {
                TotalQuestions = questions.Count,
                CorrectAnswers = correctAnswers,
                Score = score,
                Questions = questions
            };

            ViewBag.Score = score;
            ViewBag.TotalQuestions = questions.Count;
            ViewBag.CorrectAnswers = correctAnswers;

            return View(model);
        }
    }
}
