using System.Collections.Generic;
using System.Threading.Tasks;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Interfaces
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuizQuestion>> GetQuestionsAsync();
        Task<QuizQuestion> GetQuestionByIdAsync(int id);
        Task AddQuestionAsync(QuizQuestion question);
        Task UpdateQuestionAsync(QuizQuestion question);
        Task DeleteQuestionAsync(int id);
    }
}
