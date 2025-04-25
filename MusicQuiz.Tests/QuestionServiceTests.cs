using FluentAssertions;
using Moq;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MusicQuiz.Tests
{
    public class QuestionServiceTests
    {
        private readonly Mock<IQuestionService> _mockQuestionService;

        public QuestionServiceTests()
        {
            _mockQuestionService = new Mock<IQuestionService>();
        }

        [Fact]
        public async Task GetQuestionsAsync_ShouldReturnListOfQuestions_WhenCalled()
        {
            // Arrange
            var questions = new List<QuizQuestion>
            {
                new QuizQuestion { Id = 1, Question = "What is the capital of France?", CorrectAnswer = "Paris" },
                new QuizQuestion { Id = 2, Question = "What is 2 + 2?", CorrectAnswer = "4" }
            };
            _mockQuestionService.Setup(q => q.GetQuestionsAsync()).ReturnsAsync(questions);

            // Act
            var result = await _mockQuestionService.Object.GetQuestionsAsync();

            // Assert
            result.Should().NotBeNullOrEmpty();
            result.Should().HaveCount(2);
            result.Should().Contain(q => q.Question == "What is the capital of France?");
        }

        [Fact]
        public async Task GetQuestionByIdAsync_ShouldReturnQuestion_WhenIdIsValid()
        {
            // Arrange
            var question = new QuizQuestion { Id = 1, Question = "What is the capital of France?", CorrectAnswer = "Paris" };
            _mockQuestionService.Setup(q => q.GetQuestionByIdAsync(1)).ReturnsAsync(question);

            // Act
            var result = await _mockQuestionService.Object.GetQuestionByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result?.Question.Should().Be("What is the capital of France?");
        }

        [Fact]
        public async Task AddQuestionAsync_ShouldAddQuestion_WhenCalled()
        {
            // Arrange
            var question = new QuizQuestion { Id = 3, Question = "What is the largest planet?", CorrectAnswer = "Jupiter" };
            _mockQuestionService.Setup(q => q.AddQuestionAsync(question)).Returns(Task.CompletedTask);

            // Act
            await _mockQuestionService.Object.AddQuestionAsync(question);

            // Assert
            _mockQuestionService.Verify(q => q.AddQuestionAsync(question), Times.Once);
        }

        [Fact]
        public async Task UpdateQuestionAsync_ShouldUpdateQuestion_WhenCalled()
        {
            // Arrange
            var question = new QuizQuestion { Id = 1, Question = "What is the capital of Germany?", CorrectAnswer = "Berlin" };
            _mockQuestionService.Setup(q => q.UpdateQuestionAsync(question)).Returns(Task.CompletedTask);

            // Act
            await _mockQuestionService.Object.UpdateQuestionAsync(question);

            // Assert
            _mockQuestionService.Verify(q => q.UpdateQuestionAsync(question), Times.Once);
        }

        [Fact]
        public async Task DeleteQuestionAsync_ShouldDeleteQuestion_WhenIdIsValid()
        {
            // Arrange
            var questionId = 1;
            _mockQuestionService.Setup(q => q.DeleteQuestionAsync(questionId)).Returns(Task.CompletedTask);

            // Act
            await _mockQuestionService.Object.DeleteQuestionAsync(questionId);

            // Assert
            _mockQuestionService.Verify(q => q.DeleteQuestionAsync(questionId), Times.Once);
        }
    }
}
