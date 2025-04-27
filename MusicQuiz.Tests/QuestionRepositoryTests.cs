using FluentAssertions;
using Moq;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Tests
{
    public class QuestionRepositoryTests
    {
        private readonly Mock<IQuestionRepository> _mockQuestionRepository;

        public QuestionRepositoryTests()
        {
            _mockQuestionRepository = new Mock<IQuestionRepository>();
        }

        /// <summary>
        /// Test to ensure that the GetQuestionsAsync method returns a list of questions.
        /// </summary>
        /// <returns></returns>
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
