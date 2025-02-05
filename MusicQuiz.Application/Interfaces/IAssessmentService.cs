using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Interfaces
{
    public interface IAssessmentService
    {
        /// <summary>
        /// Used for practice quiz
        /// </summary>
        /// <param name="assessmentId"></param>
        /// <returns></returns>
        Task<Assessments?> GetAssessmentByIdAsync(int assessmentId);
    }
}
