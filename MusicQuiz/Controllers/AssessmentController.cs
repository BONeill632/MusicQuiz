using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Web.Models.Assessment;
using MusicQuiz.Core.Enums;
using MusicQuiz.Web.Models.Quiz;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using MusicQuiz.Application.Services;
using MusicQuiz.Core.Entities;
using MusicQuiz.Application.Interfaces;

namespace MusicQuiz.Web.Controllers
{
    [Authorize]
    public class AssessmentController(ApplicationDbContext context, UserManager<UserData> userManager, IResultsService resultsService, IAssessmentService assessmentService) : Controller
    {
        /// <summary>
        /// Assessment Index page
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> Index()
        {
            var userID = await GetUserIdAsync();
            var userAcademicYear = await GetCurrentUserAcademicYearAsync(); 

            string year = userAcademicYear;

            // Fetch assessments matching the user's academic year.
            var assessments = await context.Assessments
                .Where(a => a.AcademicYear == year)
                .OrderBy(a => a.OpenFrom)
                .ToListAsync();

            // Fetch completed assessments for this user
            var completedAssessments = await context.UsersPracticeQuizResults
                .Where(q => q.UserID == userID)
                .Select(q => q.AssessmentId)
                .ToListAsync();

            // Create the ViewModel with filtered assessments and completion check.
            var viewModel = assessments.Select(a => new AssessmentViewModel
            {
                ID = a.ID,
                AcademicYear = a.AcademicYear,
                OpenFrom = a.OpenFrom,
                OpenTo = a.OpenTo,
                TopicName = (Topic)a.TopicId,
                IsUnlocked = DateTime.Now >= a.OpenFrom && DateTime.Now <= a.OpenTo,
                IsCompleted = completedAssessments.Contains(a.ID)
            }).ToList();

            return View(viewModel);
        }


        /// <summary>
        /// Fetch the current user's academic year to fetch assessment data.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private async Task<string> GetCurrentUserAcademicYearAsync()
        {
            var userName = User.Identity?.Name;

            if (string.IsNullOrEmpty(userName))
            {
                throw new InvalidOperationException("User is not logged in.");
            }

            // Query the database for the current user's academic year.
            var user = await context.Users
                .FirstOrDefaultAsync(u => u.UserName == userName);

            return user == null ? throw new InvalidOperationException("User not found in the database.") : user.AcademicYear;
        }

        /// <summary>
        /// Start the assessment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> StartAssessment(int id)
        {
            // Find the assessment by ID.
            var assessment = await context.Assessments.FindAsync(id);

            if (assessment == null || DateTime.Now < assessment.OpenFrom || DateTime.Now > assessment.OpenTo)
            {
                TempData["ErrorMessage"] = "You cannot start this assessment at this time.";
                return RedirectToAction("Index");
            }

            // Save AssessmentID in session
            HttpContext.Session.SetInt32("AssessmentID", id);

            // Load the quiz data based on the selected topic. Difficulty for assessment is set to hard.
            var questions = context.QuizQuestions
                .Where(q => q.TopicId == (int)assessment.TopicId && q.DifficultyId == (int)DifficultyLevel.Hard)
                .ToList();

            if (questions.Count == 0)
            {
                return View("NoQuestions");
            }

            // Select 10 random questions
            var random = new Random();
            var selectedQuestions = questions.OrderBy(q => random.Next()).Take((int)QuestionQuantity.Assessment).ToList();

            var questionViewModels = selectedQuestions.Select(q =>
            {
                var options = new List<string> { q.CorrectAnswer, q.WrongAnswerOne, q.WrongAnswerTwo, q.WrongAnswerThree };
                options = [.. options.OrderBy(x => random.Next())];

                return new QuestionViewModel
                {
                    SelectedTopic = (Topic)assessment.TopicId,
                    SelectedDifficulty = DifficultyLevel.Hard,
                    Question = q.Question,
                    MusicQuestionFilePath = q.QuestionMusicFilePath,
                    MusicReferenceFilePath = q.ReferenceMusicFilePath,
                    MusicReferenceName = Path.GetFileNameWithoutExtension(q.ReferenceMusicFilePath),
                    OptionsForQuiz = options,
                    CorrectAnswer = q.CorrectAnswer
                };
            }).ToList();

            // Save questions in session
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
            var assessmentID = HttpContext.Session.GetInt32("AssessmentID") ?? 0;

            if (questions == null || questions.Count == 0)
            {
                return View("NoQuestions");
            }

            var model = questions[currentIndex];
            ViewBag.CurrentQuestionIndex = currentIndex;
            ViewBag.TotalQuestions = questions.Count;
            ViewBag.AssessmentID = assessmentID;

            return View(model);
        }


        /// <summary>
        /// Show the next question
        /// </summary>
        /// <param name="selectedOption"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NextQuestion(string selectedOption)
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : [];
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;
            var assessmentID = HttpContext.Session.GetInt32("AssessmentID") ?? 0;

            if (questions == null || questions.Count == 0)
            {
                return View("NoQuestions");
            }

            SaveUserAnswer(questions, currentIndex, selectedOption);

            currentIndex++;
            if (currentIndex >= questions.Count)
            {
                // Finish the quiz
                return RedirectToAction("QuizFinished", new { assessmentID });
            }

            HttpContext.Session.SetInt32("CurrentQuestionIndex", currentIndex);

            return RedirectToAction("ShowQuestion");
        }


        /// <summary>
        /// Finish the assessment
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> QuizFinished()
        {
            var assessmentID = HttpContext.Session.GetInt32("AssessmentID") ?? 0;

            // Await the asynchronous method call
            var assessment = await assessmentService.GetAssessmentByIdAsync(assessmentID);

            // Check if the assessment is null (it might not be found in the DB)
            if (assessment == null)
            {
                TempData["ErrorMessage"] = "Assessment not found.";
                return RedirectToAction("Index");
            }

            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) ?? [] : [];

            var userID = await GetUserIdAsync();

            decimal percentage = 0;

            if (questions.Count != 0)
            {
                percentage = CalculatePercentage(questions);
            }

            // Save to DB
            resultsService.SaveAssessmentResults(percentage, DateTime.Now, (int)DifficultyLevel.Hard, assessment.TopicId, userID, assessmentID);

            return View("QuizFinished");
        }



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
        /// Save user answer to the HTTPcontext
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="currentIndex"></param>
        /// <param name="selectedOption"></param>
        private void SaveUserAnswer(List<QuestionViewModel> questions, int currentIndex, string selectedOption)
        {
            // Set selectedOption to "Not answered" if the user doesn't choose a radio button
            if (string.IsNullOrEmpty(selectedOption))
            {
                selectedOption = "Not answered";
            }

            var currentQuestion = questions[currentIndex];
            currentQuestion.UserAnswer = selectedOption;

            var correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers") ?? 0;

            // Update the running total of correct answers
            if (currentQuestion.IsAnswered)
            {
                // If the question was previously answered, adjust the score based on the new answer
                if (selectedOption != currentQuestion.CorrectAnswer)
                {
                    correctAnswers--;
                }
                else if (selectedOption == currentQuestion.CorrectAnswer)
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
            // Save the total correct answers to session
            HttpContext.Session.SetInt32("CorrectAnswers", correctAnswers);

            // Save the updated questions back to session
            HttpContext.Session.SetString("QuizQuestions", JsonSerializer.Serialize(questions));
        }

        /// <summary>
        /// Return to previous question in the list
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PreviousQuestion()
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : [];
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;
            _ = HttpContext.Session.GetInt32("AssessmentID") ?? 0;

            if (questions == null || questions.Count == 0)
            {
                return View("NoQuestions");
            }

            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = 0;
            }

            HttpContext.Session.SetInt32("CurrentQuestionIndex", currentIndex);

            return RedirectToAction("ShowQuestion");
        }


        /// <summary>
        /// Calculate the percentage of quiz gained by the user
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        private decimal CalculatePercentage(List<QuestionViewModel> questions)
        {
            // Get the total correct answers from session
            var correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers") ?? 0;

            // Start the calculated percentage at 0
            decimal percentage = (correctAnswers / questions.Count) * 100;

            return percentage;
        }
    }
}