using MusicQuiz.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MusicQuiz.Core.Interfaces
{
    public interface IQuestionRepository
    {
        Task AddQuestionAsync(QuizQuestion question);
        Task DeleteQuestionAsync(int id);
        Task<QuizQuestion> GetQuestionByIdAsync(int id);
        Task<IEnumerable<QuizQuestion>> GetQuestionsAsync();
        Task UpdateQuestionAsync(QuizQuestion question);
    }
}
