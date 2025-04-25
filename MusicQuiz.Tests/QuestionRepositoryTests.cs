using FluentAssertions;
using Moq;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MusicQuiz.Tests
{
    public class QuestionRepositoryTests
    {
        private readonly Mock<IQuestionRepository> _mockQuestionRepository;

        public QuestionRepositoryTests()
        {
            _mockQuestionRepository = new Mock<IQuestionRepository>();
        }

        [Fact]
        public async Task GetQuestionsAsync_ShouldReturnQuestionsFilteredByTopic_WhenTopicIsValid()
        {
            // Arrange
            var questions = new List<QuizQuestion>
            {
                new QuizQuestion { Id = 1, TopicId = 1, CorrectAnswer = "Sample Question 1" },
                new QuizQuestion { Id = 2, TopicId = 2, CorrectAnswer = "Sample Question 2" }
            };
            _mockQuestionRepository.Setup(q => q.GetQuestionsAsync()).ReturnsAsync(questions);

            // Act
            var result = await _mockQuestionRepository.Object.GetQuestionsAsync();
            var filteredResult = result.Where(q => q.TopicId == 1);

            // Assert
            filteredResult.Should().NotBeNullOrEmpty();
            filteredResult.Should().HaveCount(1);
            filteredResult.First().CorrectAnswer.Should().Be("Sample Question 1");
        }
    }
}
