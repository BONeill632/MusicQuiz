using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Interfaces
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
