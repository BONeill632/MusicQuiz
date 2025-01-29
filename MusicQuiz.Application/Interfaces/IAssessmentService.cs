using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Interfaces
{
    public interface IAssessmentService
    {
        Task<Assessments?> GetAssessmentByIdAsync(int assessmentId);
    }
}
