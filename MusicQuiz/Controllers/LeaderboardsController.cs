using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Web.Models.Leaderboards;

namespace MusicQuiz.Web.Controllers
{
    public class LeaderboardsController(ApplicationDbContext context, UserManager<UserData> userManager) : BaseController
    {

        // ViewModel for passing data to the view
        [BindProperty]
        public required LeaderboardViewModel ViewModel { get; set; }

        // GET: /Leaderboards
        public async Task<IActionResult> Index(string academicYear = "24/25")
        {
            // Get the current logged-in user (if any)
            var user = await userManager.GetUserAsync(User);

            // Fetch the top users for the selected academic year
            var topUsers = await GetTopUsersByAcademicYearAsync(academicYear);

            // Fetch all users in the selected academic year (needed for user rank calculation)
            var allUsers = await GetAllUsersByAcademicYearAsync(academicYear);

            // Get the user's rank, if they are in the list of all users
            int userRank = allUsers
                .OrderByDescending(u => u.EXP)
                .Select((userData, index) => new { userData, index })
                .FirstOrDefault(u => u.userData.IntID == user?.IntID)?.index + 1 ?? -1; // -1 if user is not in the list

            // Prepare ViewModel data to be passed to the view
            ViewModel = new LeaderboardViewModel
            {
                TopUsers = topUsers,
                CurrentUser = user, // User can be null if not logged in
                SelectedAcademicYear = academicYear,
                AcademicYearOptions = GetAcademicYearOptions(), // List of filter options
                UserRank = userRank // Adding rank information for the current user
            };

            return View(ViewModel); // Use View() to return the model to the view
        }

        // Fetch all users for the selected academic year (for rank calculation)
        private async Task<List<UserData>> GetAllUsersByAcademicYearAsync(string academicYear)
        {
            if (academicYear == "All Time")
            {
                return await context.Users.ToListAsync();
            }
            else
            {
                return await context.Users
                    .Where(u => u.AcademicYear == academicYear)
                    .ToListAsync();
            }
        }

        // POST: /Leaderboards (for the filter buttons)
        [HttpPost]
        public async Task<IActionResult> IndexPost(string academicYear)
        {
            // Re-fetch data based on the selected academic year
            return await Index(academicYear); // Recalling the GET method to reload the leaderboard
        }

        // Fetch top users for the selected academic year
        private async Task<List<UserData>> GetTopUsersByAcademicYearAsync(string academicYear)
        {
            if (academicYear == "All Time")
            {
                return await context.Users
                    //Leave out 'NOTLOGGED IN' & 'ADMIN'
                    .Where(u => u.IntID != 0 || u.IntID != 1)
                    .OrderByDescending(u => u.EXP ) // Ordering by EXP for all-time leaderboard
                    .Take(25)
                    .ToListAsync();
            }
            else
            {
                return await context.Users
                    .Where(u => u.AcademicYear == academicYear && (u.IntID != 0 || u.IntID != 1)) // Filtering by the selected academic year
                    .OrderByDescending(u => u.EXP) // Ordering by EXP for the selected year
                    .Take(25)
                    .ToListAsync();
            }
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
                $"{(currentAcademicYear + 1) % 100}/{(currentAcademicYear + 2) % 100}",

                //Overall leaderboard
                "All Time"
            };

            return options;
        }
    }
}
