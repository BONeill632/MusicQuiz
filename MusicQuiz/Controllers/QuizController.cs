using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Enums;
using MusicQuiz.Web.Models;
using System.Text.Json;

namespace MusicQuiz.Web.Controllers
{
    public class QuizController(ApplicationDbContext context,
        IResultsService resultsService, UserManager<UserData> userManager) : BaseController
    {
        /// <summary>
        /// Get user ID
        /// </summary>
        /// <returns></returns>
        private async Task<string> GetUserIdAsync()
        {
            var user = await userManager.GetUserAsync(User);
            return user?.Id ?? "0";
        }

        /// <summary>
        /// Index action method for the Quiz
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            ClearQuizSession();

            var quiz = new MusicQuizViewModel();
            return View(quiz);
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
                var selectedTopicString = TempData["SelectedTopic"]?.ToString() ?? string.Empty;
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
            var questions = context.QuizQuestions
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

            var questionViewModels = selectedQuestions.Select(q =>
            {
                var options = new List<string> { q.CorrectAnswer, q.WrongAnswerOne, q.WrongAnswerTwo, q.WrongAnswerThree };
                options = [.. options.OrderBy(x => random.Next())];

                return new QuestionViewModel
                {
                    SelectedTopic = model.SelectedTopic,
                    SelectedDifficulty = model.SelectedDifficulty,
                    Question = q.Question,
                    MusicQuestionFilePath = q.QuestionMusicFilePath,
                    MusicReferenceFilePath = q.ReferenceMusicFilePath,
                    MusicReferenceName = Path.GetFileNameWithoutExtension(q.ReferenceMusicFilePath),
                    Options = options,
                    CorrectAnswer = q.CorrectAnswer,
                };
            }).ToList();

            HttpContext.Session.SetString("QuizQuestions", JsonSerializer.Serialize(questionViewModels));
            HttpContext.Session.SetInt32("CurrentQuestionIndex", 0);

            return RedirectToAction("ShowQuestion");
        }

        /// <summary>
        /// Displays the current question.
        /// </summary>
        /// <returns></returns>
        public IActionResult ShowQuestion()
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) ?? [] : [];
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;
            var answer = questions[currentIndex].UserAnswer;
            var scoreString = HttpContext.Session.GetString("Score");
            decimal score = 0;
            if (!string.IsNullOrEmpty(scoreString))
            {
                _ = decimal.TryParse(scoreString, out score);
            }

            if (questions == null || questions.Count == 0)
            {
                return View("NoQuestions");
            }

            var model = questions[currentIndex];
            ViewBag.CurrentQuestionIndex = currentIndex;
            ViewBag.TotalQuestions = questions.Count;
            ViewBag.Score = score;
            ViewBag.userAnswer = answer;
            ViewBag.Feedback = questions[currentIndex].Feedback;

            return View(model);
        }

        [HttpPost]
        public IActionResult NextQuestion(string selectedOption)
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : [];
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;

            if (questions == null || questions.Count == 0)
            {
                return View("NoQuestions");
            }

            // Save the user's answer
            SaveUserAnswer(questions, currentIndex, selectedOption);

            // Move to the next question
            currentIndex++;
            if (currentIndex >= questions.Count)
            {
                return RedirectToAction("QuizResults");
            }

            HttpContext.Session.SetInt32("CurrentQuestionIndex", currentIndex);

            return RedirectToAction("ShowQuestion");
        }

        private void SaveUserAnswer(List<QuestionViewModel> questions, int currentIndex, string selectedOption)
        {
            // Set selectedOption to "Not answered" if the user doesn't choose a radio button
            if (string.IsNullOrEmpty(selectedOption))
            {
                selectedOption = "Not answered";
            }

            var currentQuestion = questions[currentIndex];
            var answer = currentQuestion.UserAnswer;
            currentQuestion.UserAnswer = selectedOption;

            var correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers") ?? 0;

            // Update the running total of correct answers
            if (currentQuestion.IsAnswered)
            {
                // If the question was previously answered, adjust the score based on the new answer
                //Adjust the feedback
                if (answer == currentQuestion.CorrectAnswer && selectedOption != currentQuestion.CorrectAnswer)
                {
                    currentQuestion.Feedback = "Try again. ✘";
                    correctAnswers--;
                }
                else if (answer != currentQuestion.CorrectAnswer && selectedOption == currentQuestion.CorrectAnswer)
                {
                    currentQuestion.Feedback = "Correct! ✔";
                    correctAnswers++;
                }
            }
            else
            {
                // If the question was not previously answered, update the score based on the new answer
                if (selectedOption == currentQuestion.CorrectAnswer)
                {
                    currentQuestion.Feedback = "Correct! ✔";
                    correctAnswers++;
                }
                else
                {
                    currentQuestion.Feedback = "Try again. ✘";
                }
                currentQuestion.IsAnswered = true;
            }

            HttpContext.Session.SetInt32("CorrectAnswers", correctAnswers);

            // Calculate the score
            decimal score = Math.Round(correctAnswers / (decimal)questions.Count * 100, 2);
            HttpContext.Session.SetString("Score", score.ToString());

            HttpContext.Session.SetString("QuizQuestions", JsonSerializer.Serialize(questions));
        }

        [HttpPost]
        public IActionResult PreviousQuestion()
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : [];
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;

            if (questions == null || questions.Count == 0)
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
            ViewBag.Feedback = questions[currentIndex].Feedback;

            return RedirectToAction("ShowQuestion");
        }



        /// <summary>
        /// Show quiz results page (pie chart & list of questions)
        /// </summary>
        /// <returns></returns>
        public IActionResult QuizResults(string selectedAnswer)
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) ?? [] : [];
            var correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers") ?? 0;
            var scoreString = HttpContext.Session.GetString("Score");

            // Retrieve the current question index
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;

            // Save the user's answer
            SaveUserAnswer(questions, currentIndex, selectedAnswer);

            decimal score = 0;
            if (!string.IsNullOrEmpty(scoreString))
            {
                score = decimal.TryParse(scoreString, out var parsedScore) ? parsedScore : 0;
            }

            var model = new QuizResultsViewModel
            {
                TotalQuestions = questions.Count,
                CorrectAnswers = correctAnswers,
                Score = score,
                Questions = questions,
                DateOfSubmission = DateTime.Now
            };

            ViewBag.Score = score;
            ViewBag.TotalQuestions = questions.Count;
            ViewBag.CorrectAnswers = correctAnswers;
            ViewBag.DateOfSubmission = model.DateOfSubmission.ToString("dd/MM/yyyy HH:mm:ss");

            var userID = GetUserIdAsync().Result;

            resultsService.SaveQuizResults(score, model.DateOfSubmission, (int)questions.FirstOrDefault().SelectedDifficulty, (int)questions.FirstOrDefault().SelectedTopic, userID);

            ClearQuizSession();

            return View(model);
        }


    }
}
