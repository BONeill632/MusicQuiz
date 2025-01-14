using Microsoft.EntityFrameworkCore;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;

namespace MusicQuiz.Application.Services
{
    public class ResultsService(ApplicationDbContext context) : IResultsService
    {
        public void SaveQuizResults(decimal score, DateTime dateOfSubmission, int selectedDifficulty, int selectedTopic, string userID)
        {
            var quizResult = new UsersPracticeQuizResults
            {
                UserID = userID,
                UserScore = score,
                DateOfSubmission = dateOfSubmission,
                SelectedDifficulty = selectedDifficulty,
                SelectedTopic = selectedTopic
            };

            context.UsersPracticeQuizResults.Add(quizResult);
            context.SaveChanges();
        }

        public async Task<UsersPracticeQuizResults?> GetMostRecentQuizResultAsync(string userId)
        {
            return await context.UsersPracticeQuizResults
                .Where(qr => qr.UserID == userId)
                .OrderByDescending(qr => qr.DateOfSubmission)
                .FirstOrDefaultAsync();
        }
    }
}
