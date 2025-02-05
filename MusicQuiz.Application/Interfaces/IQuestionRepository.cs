using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Interfaces
{
    public interface IQuestionRepository
    {
        /// <summary>
        /// AddQuestionAsync
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        Task AddQuestionAsync(QuizQuestion question);

        /// <summary>
        /// DeleteQuestionAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteQuestionAsync(int id);

        /// <summary>
        /// GetQuestionByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<QuizQuestion> GetQuestionByIdAsync(int id);

        /// <summary>
        /// GetQuestionsAsync
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<QuizQuestion>> GetQuestionsAsync();

        /// <summary>
        /// UpdateQuestionAsync
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        Task UpdateQuestionAsync(QuizQuestion question);
    }
}
