using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Interfaces
{
    public interface IResultsService
    {
        void SaveQuizResults(decimal score, DateTime dateOfSubmission, int selectedDifficulty, int selectedTopic, string uderID);

        void SaveAssessmentResults(decimal score, DateTime dateOfSubmission, int selectedDifficulty, int selectedTopic, string uderID, int AssessmentId);

        Task<UsersPracticeQuizResults?> GetMostRecentQuizResultAsync(string userId);
    }
}
