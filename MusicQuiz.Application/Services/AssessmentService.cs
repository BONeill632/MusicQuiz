using Microsoft.EntityFrameworkCore;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;

namespace MusicQuiz.Application.Services
{
    public class AssessmentService(ApplicationDbContext context) : IAssessmentService
    {
        public Task<Assessments?> GetAssessmentByIdAsync(int assessmentID)
        {
            if (assessmentID <= 0)
            {
                return Task.FromResult<Assessments?>(null);
            }

            return context.Assessments
                .FirstOrDefaultAsync(a => a.ID == assessmentID);
        }
    }

}
