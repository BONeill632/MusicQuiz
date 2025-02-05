using Microsoft.EntityFrameworkCore;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;

namespace MusicQuiz.Application.Services
{
    public class QuestionRepository(ApplicationDbContext context) : IQuestionRepository
    {
        /// <summary>
        /// `ApplicationDbContext` instance
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<QuizQuestion>> GetQuestionsAsync()
        {
            return await context.QuizQuestions.ToListAsync();
        }

        /// <summary>
        /// AddQuestionAsync
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task IQuestionRepository.AddQuestionAsync(QuizQuestion question)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// DeleteQuestionAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task IQuestionRepository.DeleteQuestionAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// GetQuestionByIdAsync
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task<QuizQuestion> IQuestionRepository.GetQuestionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// UpdateQuestionAsync
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        Task IQuestionRepository.UpdateQuestionAsync(QuizQuestion question)
        {
            throw new NotImplementedException();
        }
    }
}
