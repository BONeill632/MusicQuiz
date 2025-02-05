using Microsoft.EntityFrameworkCore;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;

namespace MusicQuiz.Application.Services
{
    public class ResultsService(ApplicationDbContext context) : IResultsService
    {
        /// <summary>
        /// Used for practice quiz
        /// </summary>
        /// <param name="score"></param>
        /// <param name="dateOfSubmission"></param>
        /// <param name="selectedDifficulty"></param>
        /// <param name="selectedTopic"></param>
        /// <param name="userID"></param>
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

        /// <summary>
        /// Used for assessments
        /// </summary>
        /// <param name="score"></param>
        /// <param name="dateOfSubmission"></param>
        /// <param name="selectedDifficulty"></param>
        /// <param name="selectedTopic"></param>
        /// <param name="userID"></param>
        /// <param name="assessmentId"></param>
        public void SaveAssessmentResults(decimal score, DateTime dateOfSubmission, int selectedDifficulty, int selectedTopic, string userID, int assessmentId)
        {
            var quizResult = new UsersPracticeQuizResults
            {
                UserID = userID,
                UserScore = score,
                DateOfSubmission = dateOfSubmission,
                SelectedDifficulty = selectedDifficulty,
                SelectedTopic = selectedTopic,
                AssessmentId = assessmentId
            };

            context.UsersPracticeQuizResults.Add(quizResult);
            context.SaveChanges();
        }

        /// <summary>
        /// Get the most recent quiz result
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<UsersPracticeQuizResults?> GetMostRecentQuizResultAsync(string userId)
        {
            return await context.UsersPracticeQuizResults
                .Where(qr => qr.UserID == userId && qr.AssessmentId == null)
                .OrderByDescending(qr => qr.DateOfSubmission)
                .FirstOrDefaultAsync();
        }
    }
}
