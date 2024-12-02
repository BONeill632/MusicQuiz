using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;

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
    }
}
