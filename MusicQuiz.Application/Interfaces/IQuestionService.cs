using System.Collections.Generic;
using System.Threading.Tasks;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Application.Interfaces
{
    public interface IQuestionService
    {
        /// <summary>
        /// GetQuestionsAsync
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<QuizQuestion>> GetQuestionsAsync();

        /// <summary>
        /// GetQuestionByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<QuizQuestion> GetQuestionByIdAsync(int id);

        /// <summary>
        /// AddQuestionAsync
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        Task AddQuestionAsync(QuizQuestion question);

        /// <summary>
        /// UpdateQuestionAsync
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        Task UpdateQuestionAsync(QuizQuestion question);

        /// <summary>
        /// DeleteQuestionAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteQuestionAsync(int id);
    }
}
