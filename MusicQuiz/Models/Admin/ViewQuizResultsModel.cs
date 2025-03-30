using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MusicQuiz.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MusicQuiz.Web.Models.Admin
{
    public class ViewQuizResultsModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Topic { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Difficulty { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Month { get; set; }

        public List<QuizResultModel> LoggedInResults { get; set; }
        public List<QuizResultModel> NotLoggedInResults { get; set; }

        public List<decimal> ScoreDataLoggedIn { get; set; }
        public List<string> UserNamesLoggedIn { get; set; }
        public List<decimal> ScoreDataNotLoggedIn { get; set; }
        public List<string> UserNamesNotLoggedIn { get; set; }

        public IActionResult OnGet()
        {
            // Fetch data from the database
            var allLoggedInResults = GetLoggedInResultsFromDatabase();
            var allNotLoggedInResults = GetNotLoggedInResultsFromDatabase();

            // Filter data based on the selected filters
            LoggedInResults = FilterResults(allLoggedInResults, Topic, Difficulty, Month);
            NotLoggedInResults = FilterResults(allNotLoggedInResults, Topic, Difficulty, Month);

            // Prepare data for the chart
            ScoreDataLoggedIn = [.. LoggedInResults.Select(r => r.UserScore)];
            UserNamesLoggedIn = [.. LoggedInResults.Select(r => $"{r.Forename} {r.Surname}")];
            ScoreDataNotLoggedIn = [.. NotLoggedInResults.Select(r => r.UserScore)];
            UserNamesNotLoggedIn = [.. NotLoggedInResults.Select(r => $"{r.Forename} {r.Surname}")];

            return Page();
        }

        private static List<QuizResultModel> GetLoggedInResultsFromDatabase()
        {
            return [];
        }

        private static List<QuizResultModel> GetNotLoggedInResultsFromDatabase()
        {
            return [];
        }

        private static List<QuizResultModel> FilterResults(List<QuizResultModel> results, string topic, string difficulty, string month)
        {
            if (topic != "all")
            {
                results = [.. results.Where(r => r.SelectedTopic.ToString() == topic)];
            }

            if (difficulty != "all")
            {
                results = [.. results.Where(r => r.SelectedDifficulty.ToString() == difficulty)];
            }

            if (month != "all")
            {
                var selectedMonth = DateTime.ParseExact(month, "MM-yyyy", null);
                results = [.. results.Where(r => r.DateOfSubmission.Month == selectedMonth.Month && r.DateOfSubmission.Year == selectedMonth.Year)];
            }

            return results;
        }
    }
}
