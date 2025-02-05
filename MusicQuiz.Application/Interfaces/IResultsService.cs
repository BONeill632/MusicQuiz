using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Interfaces
{
    public interface IResultsService
    {
        /// <summary>
        /// Used for practice quiz
        /// </summary>
        /// <param name="score"></param>
        /// <param name="dateOfSubmission"></param>
        /// <param name="selectedDifficulty"></param>
        /// <param name="selectedTopic"></param>
        /// <param name="uderID"></param>
        void SaveQuizResults(decimal score, DateTime dateOfSubmission, int selectedDifficulty, int selectedTopic, string uderID);

        /// <summary>
        /// Used for assessments
        /// </summary>
        /// <param name="score"></param>
        /// <param name="dateOfSubmission"></param>
        /// <param name="selectedDifficulty"></param>
        /// <param name="selectedTopic"></param>
        /// <param name="uderID"></param>
        /// <param name="AssessmentId"></param>
        void SaveAssessmentResults(decimal score, DateTime dateOfSubmission, int selectedDifficulty, int selectedTopic, string uderID, int AssessmentId);

        /// <summary>
        /// Get the most recent quiz result
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        Task<UsersPracticeQuizResults?> GetMostRecentQuizResultAsync(string userId);
    }
}
