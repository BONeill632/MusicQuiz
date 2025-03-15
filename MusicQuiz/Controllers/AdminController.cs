using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Enums;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Web.Models.Admin;
using MusicQuiz.Web.Models.Quiz;
using MySqlX.XDevAPI.CRUD;
using QuestionViewModel = MusicQuiz.Web.Models.Quiz.QuestionViewModel;

namespace MusicQuiz.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController(UserManager<UserData> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context) : BaseController
    {
        /// <summary>
        /// Admin index page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Populate list of users
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Manage users roles
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Manage users roles (POST)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

            if (!string.IsNullOrEmpty(selectedRole) && !userRoles.Contains(selectedRole))
            {
                var result = await userManager.AddToRoleAsync(user, selectedRole);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to add role");
                    return View(model);
                }

                result = await userManager.RemoveFromRolesAsync(user, [.. userRoles.Except([selectedRole])]);

                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Failed to remove roles");
                    return View(model);
                }
            }

            return RedirectToAction("UserList");
        }

        /// <summary>
        /// View questions for editing
        /// </summary>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <param name="selectedTopic"></param>
        /// <param name="selectedDifficulty"></param>
        /// <returns></returns>
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
                var topic = selectedTopic.Value;
                var difficulty = selectedDifficulty.Value;

                var (questions, totalQuestions) = await SearchQuestionsAsync((int)topic, (int)difficulty, model.PageNumber, model.PageSize);
                model.Questions = questions;
                model.TotalQuestions = totalQuestions;
            }

            return View(model);
        }

        /// <summary>
        /// View questions for editing (POST)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ViewQuestions(QuestionSearchViewModel model, int pageNumber = 1)
        {
            model.PageNumber = pageNumber;
            var topic = model.SelectedTopic.HasValue ? (int)model.SelectedTopic.Value : default;
            var difficulty = model.SelectedDifficulty.HasValue ? (int)model.SelectedDifficulty.Value : default;

            var (questions, totalQuestions) = await SearchQuestionsAsync(topic, difficulty, model.PageNumber, model.PageSize);
            model.Questions = questions;
            model.TotalQuestions = totalQuestions;

            model.Topics = GetTopics();
            model.Difficulties = GetDifficulties();

            return View(model);
        }

        /// <summary>
        /// Search for questions based on topic and difficulty
        /// </summary>
        /// <param name="topic"></param>
        /// <param name="difficulty"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private async Task<(List<QuestionViewModel> Questions, int TotalQuestions)> SearchQuestionsAsync(int topic, int difficulty, int pageNumber, int pageSize)
        {
            var query = context.QuizQuestions.AsQueryable();

            if (topic != default)
            {
                query = query.Where(q => q.TopicId == topic);
            }

            if (difficulty != default)
            {
                query = query.Where(q => q.DifficultyId == difficulty);
            }

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

        /// <summary>
        /// Get list of topics
        /// </summary>
        /// <returns></returns>
        private static List<string> GetTopics()
        {
            return [.. Enum.GetValues(typeof(Topic))
                       .Cast<Topic>()
                       .Select(t => t.ToString())];
        }

        /// <summary>
        /// Get list of difficulties
        /// </summary>
        /// <returns></returns>
        private static List<string> GetDifficulties()
        {
            return [.. Enum.GetValues(typeof(DifficultyLevel))
                       .Cast<DifficultyLevel>()
                       .Select(d => d.ToString())];
        }

        /// <summary>
        /// Edit question from Admin page
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Edit question from Admin page (POST)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Get list of music files
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetMusicFiles()
        {
            var musicFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Music");
            var musicFiles = Directory.GetFiles(musicFolder, "*.*", SearchOption.AllDirectories)
                                      .Select(f => "/Music/" + f[(musicFolder.Length + 1)..])
                                      .ToList();

            return Json(musicFiles);
        }

        /// <summary>
        /// Upload music file
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
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
        public IActionResult AddAssessment()
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
        public async Task<IActionResult> AddAssessment(AssessmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var assessment = new Assessments
                {
                    AcademicYear = model.AcademicYear ?? "Unknown",
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
        /// This is more of a just-in-case rather than necessary
        /// The users of the app will typically be for the module in that year.
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

        /// <summary>
        /// View assessments
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ViewAssessments()
        {
            var model = new AssessmentSearchViewModel
            {
                AcademicYears = await context.Assessments
                    .Select(a => a.AcademicYear)
                    .Distinct()
                    .OrderByDescending(y => y)
                    .ToListAsync(),
                Topics = GetTopics(),
                Assessments = []
            };

            return View(model);
        }

        /// <summary>
        /// View assessments (POST)
        /// </summary>
        /// <param name="model"></param>
        /// <param name="pageNumber"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ViewAssessments(AssessmentSearchViewModel model, int pageNumber = 1)
        {
            model.PageNumber = pageNumber;
            model.PageSize = model.PageSize > 0 ? model.PageSize : 20;
            var selectedYear = model.SelectedYear ?? "";
            var selectedTopic = model.SelectedTopic.HasValue ? (int)model.SelectedTopic.Value : default;

            var (assessments, totalAssessments) = await SearchAssessmentsAsync(selectedYear, selectedTopic, model.PageNumber, model.PageSize);
            model.Assessments = assessments;
            model.TotalAssessments = totalAssessments;

            model.AcademicYears = await context.Assessments
                .Select(a => a.AcademicYear)
                .Distinct()
                .OrderByDescending(y => y)
                .ToListAsync();

            model.Topics = GetTopics();

            return View(model);
        }

        /// <summary>
        /// Search for assessments based on year and topic
        /// </summary>
        /// <param name="selectedYear"></param>
        /// <param name="selectedTopic"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        private async Task<(List<AssessmentViewModel> Assessments, int TotalAssessments)> SearchAssessmentsAsync(string selectedYear, int selectedTopic, int pageNumber, int pageSize)
        {
            var query = context.Assessments.AsQueryable();

            if (!string.IsNullOrEmpty(selectedYear))
            {
                query = query.Where(a => a.AcademicYear == selectedYear);
            }

            if (selectedTopic != default)
            {
                query = query.Where(a => a.TopicId == selectedTopic);
            }

            var totalAssessments = await query.CountAsync();

            var assessments = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(a => new AssessmentViewModel
                {
                    ID = a.ID,
                    AcademicYear = a.AcademicYear,
                    SelectedTopic = (Topic)a.TopicId,
                    OpenFrom = a.OpenFrom,
                    OpenTo = a.OpenTo
                })
                .ToListAsync();

            return (assessments, totalAssessments);
        }

        /// <summary>
        /// Edit an existing assessment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> EditAssessment(int id)
        {
            var assessment = await context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }

            var model = new AssessmentViewModel
            {
                ID = assessment.ID,
                AcademicYear = assessment.AcademicYear,
                OpenFrom = assessment.OpenFrom,
                OpenTo = assessment.OpenTo,
                SelectedTopic = (MusicQuiz.Core.Enums.Topic)assessment.TopicId,
                AcademicYearOptions = GetAcademicYearOptions()
            };

            return View(model);
        }

        /// <summary>
        /// Edit an existing assessment (POST)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAssessment(int id, AssessmentViewModel model)
        {
            if (id != model.ID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var assessment = await context.Assessments.FindAsync(id);
                if (assessment == null)
                {
                    return NotFound();
                }

                assessment.AcademicYear = model.AcademicYear ?? "Unknown";
                assessment.OpenFrom = model.OpenFrom;
                assessment.OpenTo = model.OpenTo;
                assessment.TopicId = (int)model.SelectedTopic;

                await context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Assessment updated successfully!";
                return RedirectToAction("Index");
            }

            model.AcademicYearOptions = GetAcademicYearOptions();
            return View(model);
        }

        /// <summary>
        /// Delete an assessment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> DeleteAssessment(int id)
        {
            var assessment = await context.Assessments.FindAsync(id);
            if (assessment == null)
            {
                return NotFound();
            }

            var takenCount = await context.UsersPracticeQuizResults
                .CountAsync(ar => ar.AssessmentId == id);

            var model = new DeleteAssessmentViewModel
            {
                AssessmentId = id,
                AcademicYear = assessment.AcademicYear,
                Topic = (Topic)assessment.TopicId,
                TakenCount = takenCount,
                OpenFrom = assessment.OpenFrom,
                OpenTo = assessment.OpenTo
            };

            return View(model);
        }

        /// <summary>
        /// Delete an assessment (POST)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAssessment(DeleteAssessmentViewModel model)
        {
            var assessment = await context.Assessments.FindAsync(model.AssessmentId);
            if (assessment == null)
            {
                return NotFound();
            }

            // Optionally delete associated results
            if (model.DeleteAssociatedResults)
            {
                var results = await context.UsersPracticeQuizResults
                    .Where(ar => ar.AssessmentId == model.AssessmentId)
                    .ToListAsync();

                context.UsersPracticeQuizResults.RemoveRange(results);
            }

            // Delete the assessment
            context.Assessments.Remove(assessment);
            await context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Assessment and related data deleted successfully.";
            return RedirectToAction("ViewAssessments");
        }

        public IActionResult UserLogins()
        {
            // Get the Role ID for the "Admin" role
            var adminRoleId = context.Roles
                .Where(r => r.Name == "Admin")
                .Select(r => r.Id)
                .FirstOrDefault();

            // Get all non-admin users with a valid last login date and their login dates
            var userLogins = context.Users
                .Where(u => u.LastLoggedIn != DateTime.MinValue && !context.UserRoles.Any(ur => ur.UserId == u.Id && ur.RoleId == adminRoleId))
                .OrderByDescending(u => u.LastLoggedIn)
                .Select(u => new UserLoginsViewModel
                {
                    Id = u.Id,
                    UserName = $"{u.FirstName} {u.LastName}",
                    StudentID = u.StudentID,
                    Email = u.Email,
                    LastLoginDate = u.LastLoggedIn
                })
                .ToList();

            var loginDates = userLogins.Select(u => u.LastLoginDate).ToList();

            // Get the start of the current week (Monday)
            DateTime today = DateTime.UtcNow;
            DateTime currentWeekStart = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday).Date;

            // Process weekly data (Monday-Sunday grouping)
            int[] weeklyCounts = new int[5];

            for (int i = 0; i < 4; i++)
            {
                DateTime weekStart = currentWeekStart.AddDays(-7 * i);

                // End of the week (Sunday 23:59:59.9999999)
                DateTime weekEnd = currentWeekStart.AddDays(-7 * (i - 1)).AddTicks(-1);

                weeklyCounts[i] = loginDates.Count(l => l >= weekStart && l < weekEnd);
            }

            // Count all logins older than the end of week 3
            DateTime threeWeeksAgoEnd = currentWeekStart.AddDays(-21);
            weeklyCounts[4] = loginDates.Count(l => l < threeWeeksAgoEnd);

            // Assign the computed weekly counts to the first user in the list
            if (userLogins.Count != 0)
            {
                userLogins.First().WeeklyLoginCounts = weeklyCounts;
            }

            return View(userLogins);
        }

        [HttpGet]
        public IActionResult ManageMusicFiles()
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMusicFile(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return BadRequest("File name is required");
            }

            var musicFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Music");
            var filePath = Path.Combine(musicFolder, fileName.Replace("/Music/", ""));

            if (System.IO.File.Exists(filePath))
            {
                // Delete the file
                System.IO.File.Delete(filePath);

                // Delete corresponding questions
                var questionsToDelete = await context.QuizQuestions
                    .Where(q => q.QuestionMusicFilePath == fileName || q.ReferenceMusicFilePath == fileName)
                    .ToListAsync();

                context.QuizQuestions.RemoveRange(questionsToDelete);
                await context.SaveChangesAsync();

                return Ok();
            }
            return NotFound();
        }
    }
}