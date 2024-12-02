using System.Collections.Generic;
using System.Threading.Tasks;
using MusicQuiz.Core.Entities;
using MusicQuiz.Application.Interfaces;

namespace MusicQuiz.Application.Services
{
    public class QuestionService(IQuestionRepository questionRepository) : IQuestionService
    {
        public async Task<IEnumerable<QuizQuestion>> GetQuestionsAsync()
        {
            return await questionRepository.GetQuestionsAsync();
        }

        public async Task<QuizQuestion> GetQuestionByIdAsync(int id)
        {
            return await questionRepository.GetQuestionByIdAsync(id);
        }

        public async Task AddQuestionAsync(QuizQuestion question)
        {
            await questionRepository.AddQuestionAsync(question);
        }

        public async Task UpdateQuestionAsync(QuizQuestion question)
        {
            await questionRepository.UpdateQuestionAsync(question);
        }

        public async Task DeleteQuestionAsync(int id)
        {
            await questionRepository.DeleteQuestionAsync(id);
        }
    }
}
