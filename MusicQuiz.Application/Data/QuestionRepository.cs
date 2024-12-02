using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Interfaces;

namespace MusicQuiz.Application.Data
{
    public class QuestionRepository(ApplicationDbContext context) : IQuestionRepository
    {
        public async Task<IEnumerable<QuizQuestion>> GetQuestionsAsync()
        {
            return await context.QuizQuestions.ToListAsync();
        }

        Task IQuestionRepository.AddQuestionAsync(QuizQuestion question)
        {
            throw new NotImplementedException();
        }

        Task IQuestionRepository.DeleteQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<QuizQuestion> IQuestionRepository.GetQuestionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task IQuestionRepository.UpdateQuestionAsync(QuizQuestion question)
        {
            throw new NotImplementedException();
        }
    }
}
