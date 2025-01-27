using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Web.Models.Assessment;
using MusicQuiz.Core.Enums;

namespace MusicQuiz.Web.Controllers
{
    public class AssessmentController(ApplicationDbContext context) : Controller
    {

        // GET: Assessments
        public async Task<IActionResult> Index()
        {
            var userAcademicYear = GetCurrentUserAcademicYearAsync(); // Fetch the user's academic year.

            string year = userAcademicYear.Result;

            // Fetch assessments matching the user's academic year.
            var assessments = await context.Assessments
                .Where(a => a.AcademicYear == year)
                .OrderBy(a => a.OpenFrom)
                .ToListAsync();

            // Create the ViewModel with filtered assessments.
            var viewModel = assessments.Select(a => new AssessmentViewModel
            {
                ID = a.ID,
                AcademicYear = a.AcademicYear,
                OpenFrom = a.OpenFrom,
                OpenTo = a.OpenTo,
                TopicName = (Topic)a.TopicId,
                IsUnlocked = DateTime.Now >= a.OpenFrom && DateTime.Now <= a.OpenTo
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


        // POST: Start Assessment
        public async Task<IActionResult> StartAssessment(int id)
        {
            // Find the assessment by ID.
            var assessment = await context.Assessments.FindAsync(id);

            if (assessment == null || DateTime.Now < assessment.OpenFrom || DateTime.Now > assessment.OpenTo)
            {
                TempData["ErrorMessage"] = "You cannot start this assessment at this time.";
                return RedirectToAction("Index");
            }

            // Redirect to the quiz logic or assessment page.
            return RedirectToAction("StartQuiz", new { assessmentId = id });
        }
    }
}