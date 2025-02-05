using System.Collections.Generic;
using System.Threading.Tasks;
using MusicQuiz.Core.Entities;
using MusicQuiz.Application.Interfaces;

namespace MusicQuiz.Application.Services
{
    public class QuestionService(IQuestionRepository questionRepository) : IQuestionService
    {
        /// <summary>
        /// GetQuestionsAsync
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<QuizQuestion>> GetQuestionsAsync()
        {
            return await questionRepository.GetQuestionsAsync();
        }

        /// <summary>
        /// GetQuestionByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<QuizQuestion> GetQuestionByIdAsync(int id)
        {
            return await questionRepository.GetQuestionByIdAsync(id);
        }

        /// <summary>
        /// AddQuestionAsync
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public async Task AddQuestionAsync(QuizQuestion question)
        {
            await questionRepository.AddQuestionAsync(question);
        }

        /// <summary>
        /// UpdateQuestionAsync
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public async Task UpdateQuestionAsync(QuizQuestion question)
        {
            await questionRepository.UpdateQuestionAsync(question);
        }

        /// <summary>
        /// DeleteQuestionAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteQuestionAsync(int id)
        {
            await questionRepository.DeleteQuestionAsync(id);
        }
    }
}
