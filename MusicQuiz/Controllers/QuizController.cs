using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Enums;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Web.Models;
using MusicQuiz.Web.Models.Home;
using MusicQuiz.Web.Models.Quiz;
using System.ComponentModel;
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

            //Select random questions from DB where the difficulty & topic match
            var selectedQuestions = questions.OrderBy(q => random.Next()).Take(10).ToList();

            var questionViewModels = selectedQuestions.Select(q =>
            {
                //List options
                var options = new List<string> { q.CorrectAnswer, q.WrongAnswerOne, q.WrongAnswerTwo, q.WrongAnswerThree };

                //Randomize order so users cannot predict answer locations
                options = [.. options.OrderBy(x => random.Next())];

                return new QuestionViewModel
                {
                    SelectedTopic = model.SelectedTopic,
                    SelectedDifficulty = model.SelectedDifficulty,
                    Question = q.Question,
                    MusicQuestionFilePath = q.QuestionMusicFilePath,
                    MusicReferenceFilePath = q.ReferenceMusicFilePath,
                    MusicReferenceName = Path.GetFileNameWithoutExtension(q.ReferenceMusicFilePath),
                    OptionsForQuiz = options,
                    CorrectAnswer = q.CorrectAnswer,
                    AttemptNumber = 0,
                    EXP = 0
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

            // Update question statuses for all questions
            var questionStatuses = questions.Select(q =>
            {
                if (!q.IsAnswered)
                {
                    return "unanswered";
                }
                else if (q.FirstAnswer == q.CorrectAnswer)
                {
                    return "correct-first";
                }
                else if (q.UserAnswer == q.CorrectAnswer && q.AttemptNumber > 1)
                {
                    return "correct-multiple";
                }
                else
                {
                    return "incorrect";
                }
            }).ToList();

            // Store question statuses in ViewBag
            ViewBag.QuestionStatuses = questionStatuses;

            var model = questions[currentIndex];
            ViewBag.CurrentQuestionIndex = currentIndex;
            ViewBag.TotalQuestions = questions.Count;
            ViewBag.Score = score;
            ViewBag.userAnswer = answer;
            ViewBag.Feedback = questions[currentIndex].Feedback;

            return View(model);
        }


        /// <summary>
        /// Show the next question
        /// </summary>
        /// <param name="selectedOption"></param>
        /// <param name="attemptNumber"></param>
        /// <param name="firstUserAnswer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult NextQuestion(string selectedOption, int attemptNumber, string firstUserAnswer)
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) : [];
            var currentIndex = HttpContext.Session.GetInt32("CurrentQuestionIndex") ?? 0;

            if (questions == null || questions.Count == 0)
            {
                return View("NoQuestions");
            }

            // Save the user's answer and first answer
            SaveUserAnswer(questions, currentIndex, selectedOption, attemptNumber, firstUserAnswer);

            // Move to the next question
            currentIndex++;
            if (currentIndex >= questions.Count)
            {
                // Finish the quiz
                return RedirectToAction("QuizResults");
            }

            HttpContext.Session.SetInt32("CurrentQuestionIndex", currentIndex);

            return RedirectToAction("ShowQuestion");
        }

        /// <summary>
        /// Save user answer to the HTTPcontext
        /// </summary>
        /// <param name="questions"></param>
        /// <param name="currentIndex"></param>
        /// <param name="selectedOption"></param>
        /// <param name="attemptNumber"></param>
        /// <param name="firstUserAnswer"></param>
        private void SaveUserAnswer(List<QuestionViewModel> questions, int currentIndex, string selectedOption, int attemptNumber, string firstUserAnswer)
        {
            // Set selectedOption to "Not answered" if the user doesn't choose a radio button
            if (string.IsNullOrEmpty(selectedOption))
            {
                selectedOption = "Not answered";
            }

            var currentQuestion = questions[currentIndex];
            var answer = firstUserAnswer;
            currentQuestion.AttemptNumber = attemptNumber;
            currentQuestion.FirstAnswer = answer;
            currentQuestion.UserAnswer = selectedOption;

            if (attemptNumber > 1)
            {
                // Reassign the answer to handle the retry case
                currentQuestion.UserAnswer = selectedOption;
            }

            var correctAnswers = HttpContext.Session.GetInt32("CorrectAnswers") ?? 0;

            // Update the running total of correct answers
            if (currentQuestion.IsAnswered)
            {
                // If the question was previously answered, adjust the score based on the new answer
                if (answer == currentQuestion.FirstAnswer && selectedOption != currentQuestion.CorrectAnswer)
                {
                    currentQuestion.Feedback = "Try again. ✘";
                    correctAnswers--;
                }
                else if (answer != currentQuestion.FirstAnswer && selectedOption == currentQuestion.CorrectAnswer)
                {
                    currentQuestion.Feedback = "Correct! ✔";
                    attemptNumber++;

                    if (attemptNumber < 4)
                    {
                        correctAnswers++;
                    }
                }
            }
            else
            {
                // If the question was not previously answered, update the score based on the new answer
                if (selectedOption == currentQuestion.CorrectAnswer)
                {
                    currentQuestion.Feedback = "Correct! ✔";

                    // Correct answer increases score
                    correctAnswers++;
                }
                else
                {
                    currentQuestion.Feedback = "Try again. ✘";

                    // Increment attempt number if answer is wrong
                    attemptNumber++;
                }
                currentQuestion.IsAnswered = true;
            }

            //WORKING OUT SCORE
            decimal score;

            // Check if it's the first attempt
            if (currentIndex == 0)
            {
                score = 0;
            }
            else
            {
                // If not the first attempt, retrieve the previous score from session
                var scoreString = HttpContext.Session.GetString("Score");
                score = scoreString != null ? decimal.Parse(scoreString) : 0;
            }


            // Update the attempt number and EXP based on the number of attempts
            currentQuestion.AttemptNumber = attemptNumber;

            // Calculate the score for the current attempt
            decimal scoreForQuestion;

            switch (attemptNumber)
            {
                case 1:
                    currentQuestion.EXP = (int)MusicQuiz.Core.Enums.EXP.One;
                    scoreForQuestion = Math.Round((decimal)100 / questions.Count, 2);
                    break;
                case 2:
                    currentQuestion.EXP = (int)MusicQuiz.Core.Enums.EXP.Two;
                    scoreForQuestion = Math.Round(((decimal)100 / questions.Count) / 2, 2);
                    break;
                case 3:
                    currentQuestion.EXP = (int)MusicQuiz.Core.Enums.EXP.Three;
                    scoreForQuestion = Math.Round(((decimal)100 / questions.Count) / 3, 2);
                    break;
                default:
                    currentQuestion.EXP = (int)MusicQuiz.Core.Enums.EXP.Default;
                    scoreForQuestion = 0;
                    break;
            }

            // Add the score for the current question to the total score
            //IF the answer has been answered correctly
            score += currentQuestion.UserAnswer == currentQuestion.CorrectAnswer ? scoreForQuestion : 0;

            // Save the updated score to session
            HttpContext.Session.SetString("Score", score.ToString());

            // Save the total correct answers to session (assuming correctAnswers is already calculated elsewhere)
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

        public IActionResult QuizResults()
        {
            var questionsJson = HttpContext.Session.GetString("QuizQuestions");
            var questions = questionsJson != null ? JsonSerializer.Deserialize<List<QuestionViewModel>>(questionsJson) ?? [] : [];

            var scoreString = HttpContext.Session.GetString("Score");

            var rightFirstTime = 0;
            var rightSecondTime = 0;
            var rightThirdTime = 0;
            var rightFourthTime = 0;
            var incorrectAnswers = 0;

            decimal score = 0;

            if (!string.IsNullOrEmpty(scoreString))
            {
                score = decimal.TryParse(scoreString, out var parsedScore) ? parsedScore : 0;
            }

            // Loop through all the questions and calculate the counts
            foreach (var question in questions)
            {
                if (question.FirstAnswer == question.CorrectAnswer)
                {
                    rightFirstTime++;  // First answer was correct
                }
                else if (question.UserAnswer == question.CorrectAnswer && question.FirstAnswer != question.CorrectAnswer)
                {
                    switch (question.AttemptNumber)
                    {
                        case 1:
                            rightFirstTime++;
                            break;
                        case 2:
                            rightSecondTime++;
                            break;
                        case 3:
                            rightThirdTime++;
                            break;
                        case 4:
                            rightFourthTime++;
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    incorrectAnswers++;
                }
            }

            var model = new QuizResultsViewModel
            {
                TotalQuestions = questions.Count,
                Score = score,
                Questions = questions,
                DateOfSubmission = DateTime.Now
            };

            //ViewBag to populate JS
            ViewBag.Score = score;
            ViewBag.TotalQuestions = questions.Count;
            ViewBag.RightFirstTime = rightFirstTime;
            ViewBag.RightSecondTime = rightSecondTime;
            ViewBag.RightThirdTime = rightThirdTime;
            ViewBag.RightFourthTime = rightFourthTime;
            ViewBag.IncorrectAnswers = incorrectAnswers;
            ViewBag.DateOfSubmission = model.DateOfSubmission.ToString("dd/MM/yyyy HH:mm:ss");

            var userID = GetUserIdAsync().Result;

            if (questions.Count != 0)
            {
                decimal percentage = (decimal)CalculatePercentage(questions);

                var firstQuestion = questions.First();
                resultsService.SaveQuizResults(score, model.DateOfSubmission, (int)firstQuestion.SelectedDifficulty, (int)firstQuestion.SelectedTopic, userID);

                // Update user's EXP
                var user = userManager.FindByIdAsync(userID).Result;
                if (user != null)
                {
                    int expGained = CalculateExpGained(percentage, (int)firstQuestion.SelectedDifficulty);
                    user.EXP += expGained;
                    userManager.UpdateAsync(user).Wait();
                }
            }
            //ClearQuizSession();

            return View(model);
        }

        /// <summary>
        /// Calculate the percentage of quiz gained by the user
        /// </summary>
        /// <param name="questions"></param>
        /// <returns></returns>
        private static int CalculatePercentage(List<QuestionViewModel> questions)
        {
            int percentage = 0;

            foreach (var question in questions)
            {
                if (question.CorrectAnswer.Equals(question.UserAnswer))
                {
                    percentage += question.EXP;
                }
            }
            return percentage;
        }

        /// <summary>
        /// Calculate the EXP gained depending on the difficulty level
        /// </summary>
        /// <param name="expGained"></param>
        /// <param name="difficultyLevel"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        private static int CalculateExpGained(decimal expGained, int difficultyLevel)
        {

            switch (difficultyLevel)
            {
                case (int)DifficultyLevel.Easy:
                    // No change to expGained
                    break;
                case (int)DifficultyLevel.Medium:
                    //Double exp for medium difficulty
                    expGained *= 2;
                    break;
                case (int)DifficultyLevel.Hard:
                    //Triple exp for hard difficulty
                    expGained *= 3;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(difficultyLevel), difficultyLevel, null);
            }

            return (int)expGained;
        }
    }
}
