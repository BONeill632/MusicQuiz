using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Enums;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Web.Models.Admin;
using MusicQuiz.Web.Models.Quiz;
using QuestionViewModel = MusicQuiz.Web.Models.Quiz.QuestionViewModel;

namespace MusicQuiz.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context) : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UserList()
        {
            var users = await userManager.Users.ToListAsync();
            var userListViewModel = users.Select(user => new UserListViewModel
            {
                UserName = user.UserName ?? "Unknown",
                UserId = user.Id ?? "Unknown",
                Email = user.Email ?? "Unknown"
            }).ToList();

            return View(userListViewModel);
        }

        public async Task<IActionResult> Manage(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return NotFound();
            }

            var model = new ManageUserRolesViewModel
            {
                UserId = user.Id ?? "Unknown",
                Email = user.Email ?? "Unknown",
                FirstName = user.FirstName ?? "Unknown",
                LastName = user.LastName ?? "Unknown",
                StudentID = user.StudentID ?? "Unknown",
                Roles = await roleManager.Roles.ToListAsync(),
                UserRoles = await userManager.GetRolesAsync(user),
                SelectedRole = (await userManager.GetRolesAsync(user)).FirstOrDefault() ?? "User"
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(ManageUserRolesViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                return NotFound();
            }

            var userRoles = await userManager.GetRolesAsync(user);
            var selectedRole = model.SelectedRole;

            if (!userRoles.Contains(selectedRole))
            {
                var result = await userManager.AddToRoleAsync(user, selectedRole);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to add role");
                    return View(model);
                }

                result = await userManager.RemoveFromRolesAsync(user, userRoles.Except([selectedRole]));

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to remove roles");
                    return View(model);
                }
            }

            return RedirectToAction("UserList");
        }

        [HttpGet]
        public async Task<IActionResult> ViewQuestions(int pageNumber = 1, int pageSize = 20, Topic? selectedTopic = null, DifficultyLevel? selectedDifficulty = null)
        {
            var model = new QuestionSearchViewModel
            {
                SelectedTopic = selectedTopic,
                SelectedDifficulty = selectedDifficulty,
                PageNumber = pageNumber,
                PageSize = pageSize,
                Topics = GetTopics(),
                Difficulties = GetDifficulties()
            };

            if (selectedTopic.HasValue && selectedDifficulty.HasValue)
            {
                var topic = (int?)model.SelectedTopic ?? default;
                var difficulty = (int?)model.SelectedDifficulty ?? default;

                var (questions, totalQuestions) = await SearchQuestionsAsync(topic, difficulty, model.PageNumber, model.PageSize);
                model.Questions = questions;
                model.TotalQuestions = totalQuestions;
            }


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ViewQuestions(QuestionSearchViewModel model, int pageNumber = 1)
        {
            model.PageNumber = pageNumber;
            var topic = (int?)model.SelectedTopic ?? default;
            var difficulty = (int?)model.SelectedDifficulty ?? default;

            var (questions, totalQuestions) = await SearchQuestionsAsync(topic, difficulty, model.PageNumber, model.PageSize);
            model.Questions = questions;
            model.TotalQuestions = totalQuestions;

            model.Topics = GetTopics();
            model.Difficulties = GetDifficulties();

            return View(model);
        }


        private async Task<(List<QuestionViewModel> Questions, int TotalQuestions)> SearchQuestionsAsync(int topic, int difficulty, int pageNumber, int pageSize)
        {
            var query = context.QuizQuestions
                .Where(q => q.TopicId == topic && q.DifficultyId == difficulty);

            var totalQuestions = await query.CountAsync();

            var questions = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(q => new QuestionViewModel
                {
                    QuestionID = q.Id,
                    SelectedTopic = (Topic)q.TopicId,
                    SelectedDifficulty = (DifficultyLevel)q.DifficultyId,
                    Question = q.Question,
                    MusicQuestionFilePath = q.QuestionMusicFilePath,
                    MusicReferenceFilePath = q.ReferenceMusicFilePath,
                    MusicReferenceName = q.ReferenceMusicFilePath,
                    OptionsForQuiz = new List<string> { q.CorrectAnswer, q.WrongAnswerOne, q.WrongAnswerTwo, q.WrongAnswerThree },
                    CorrectAnswer = q.CorrectAnswer,
                })
                .ToListAsync();

            return (questions, totalQuestions);
        }

        private static List<string> GetTopics()
        {
            return Enum.GetValues(typeof(Topic))
                       .Cast<Topic>()
                       .Select(t => t.ToString())
                       .ToList();
        }

        private static List<string> GetDifficulties()
        {
            return Enum.GetValues(typeof(DifficultyLevel))
                       .Cast<DifficultyLevel>()
                       .Select(d => d.ToString())
                       .ToList();
        }

        [HttpGet]
        public async Task<IActionResult> EditQuestion(int id)
        {
            var question = await context.QuizQuestions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            var model = new QuestionViewModel
            {
                QuestionID = question.Id,
                SelectedTopic = (Topic)question.TopicId,
                SelectedDifficulty = (DifficultyLevel)question.DifficultyId,
                Question = question.Question,
                MusicQuestionFilePath = question.QuestionMusicFilePath,
                MusicReferenceFilePath = question.ReferenceMusicFilePath,
                Options = new QuizSelectableAnswers
                {
                    CorrectAnswer = question.CorrectAnswer,
                    WrongAnswerOne = question.WrongAnswerOne,
                    WrongAnswerTwo = question.WrongAnswerTwo,
                    WrongAnswerThree = question.WrongAnswerThree
                },
            };

            GetMusicFiles();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditQuestion(QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = await context.QuizQuestions.FindAsync(model.QuestionID);
                if (question == null)
                {
                    return NotFound();
                }

                question.TopicId = (int)model.SelectedTopic;
                question.DifficultyId = (int)model.SelectedDifficulty;
                question.Question = model.Question;
                question.QuestionMusicFilePath = model.MusicQuestionFilePath;
                question.ReferenceMusicFilePath = model.MusicReferenceFilePath;
                question.CorrectAnswer = model.Options.CorrectAnswer;
                question.WrongAnswerOne = model.Options.WrongAnswerOne;
                question.WrongAnswerTwo = model.Options.WrongAnswerTwo;
                question.WrongAnswerThree = model.Options.WrongAnswerThree;

                context.QuizQuestions.Update(question);
                await context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Question edited successfully";
                return RedirectToAction("EditQuestion", new { id = model.QuestionID });
            }

            return View(model);
        }




        [HttpGet]
        public IActionResult GetMusicFiles()
        {
            var musicFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Music");
            var musicFiles = Directory.GetFiles(musicFolder, "*.*", SearchOption.AllDirectories)
                                      .Select(f => "/Music/" + f[(musicFolder.Length + 1)..])
                                      .ToList();

            return Json(musicFiles);
        }

        [HttpPost]
        public async Task<IActionResult> UploadMusicFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file selected");
            }

            var musicFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Music");
            var filePath = Path.Combine(musicFolder, file.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { filePath = "/Music/" + file.FileName });
        }

        /// <summary>
        /// Delete question from Admin page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await context.QuizQuestions.FindAsync(id);
            if (question == null)
            {
                return NotFound();
            }

            context.QuizQuestions.Remove(question);
            await context.SaveChangesAsync();


            TempData["SuccessMessage"] = "Question deleted successfully";
            return RedirectToAction("ViewQuestions");
        }

        /// <summary>
        /// Accessing the add question page
        /// </summary>
        /// <returns></returns>
        public IActionResult AddQuestion()
        {
            var model = new QuestionViewModel
            {
                Options = new QuizSelectableAnswers
                {
                    CorrectAnswer = string.Empty,
                    WrongAnswerOne = string.Empty,
                    WrongAnswerTwo = string.Empty,
                    WrongAnswerThree = string.Empty
                }
            };

            GetMusicFiles();

            return View(model);
        }

        /// <summary>
        /// post the above add question page
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddQuestion(QuestionViewModel model)
        {
            if (ModelState.IsValid)
            {
                var question = new QuizQuestion
                {
                    TopicId = (int)model.SelectedTopic,
                    DifficultyId = (int)model.SelectedDifficulty,
                    Question = model.Question,
                    QuestionMusicFilePath = model.MusicQuestionFilePath,
                    ReferenceMusicFilePath = model.MusicReferenceFilePath,
                    CorrectAnswer = model.Options.CorrectAnswer,
                    WrongAnswerOne = model.Options.WrongAnswerOne,
                    WrongAnswerTwo = model.Options.WrongAnswerTwo,
                    WrongAnswerThree = model.Options.WrongAnswerThree
                };

                context.QuizQuestions.Add(question);
                await context.SaveChangesAsync();


                TempData["SuccessMessage"] = "Question added successfully";
                return RedirectToAction("ViewQuestions");
            }

            return View(model);
        }

        /// <summary>
        /// Create an assessment for students to sit
        /// </summary>
        /// <returns></returns>
        public IActionResult CreateAssessment()
        {
            var model = new AssessmentViewModel
            {
                OpenFrom = DateTime.Now,
                OpenTo = DateTime.Now.AddDays(1),
                AcademicYearOptions = GetAcademicYearOptions()
            };
            return View(model);
        }


        /// <summary>
        /// Create an assessment for students to sit
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAssessment(AssessmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var assessment = new Assessments
                {
                    AcademicYear = model.AcademicYear,
                    OpenFrom = model.OpenFrom,
                    OpenTo = model.OpenTo,
                    TopicId = (int)model.SelectedTopic,
                    DateSubmitted = DateTime.Now // Auto-set submission date
                };

                context.Assessments.Add(assessment);
                await context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Assessment created successfully!";
                return RedirectToAction("Index"); // Redirect to a list page or wherever you need
            }

            return View(model);
        }

        /// <summary>
        /// Getting list of academic years, this year, the previous year and next
        /// This is more of a just-in-case rather than necesscary
        /// The users of the app will tpically be for the modue in that year.
        /// They will need to change this in the user section if they use this application
        /// for more than an academic year as this will be used for leaderboards and assessments
        /// </summary>
        /// <returns></returns>
        public List<string> GetAcademicYearOptions()
        {
            var currentYear = DateTime.Now.Year;
            var currentMonth = DateTime.Now.Month;

            // Adjust the logic to consider the current academic year as 24/25 for Sept - Aug
            var currentAcademicYear = (currentMonth >= 9 && currentMonth <= 12)
                ? currentYear
                : (currentMonth >= 1 && currentMonth <= 8) ? currentYear - 1 : currentYear;

            // Generate the correct academic year options
            var options = new List<string>
            {
                // Previous academic year
                $"{(currentAcademicYear - 1) % 100}/{currentAcademicYear % 100}",

                // Current academic year
                $"{currentAcademicYear % 100}/{(currentAcademicYear + 1) % 100}",

                // Next academic year
                $"{(currentAcademicYear + 1) % 100}/{(currentAcademicYear + 2) % 100}"
            };

            return options;
        }

    }
}