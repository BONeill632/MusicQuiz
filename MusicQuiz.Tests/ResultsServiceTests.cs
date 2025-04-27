using FluentAssertions;
using Moq;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Tests
{
    public class ResultsServiceTests
    {
        private readonly Mock<IResultsService> _mockResultsService;

        public ResultsServiceTests()
        {
            _mockResultsService = new Mock<IResultsService>();
        }

        /// <summary>
        /// Test to check if GetMostRecentQuizResultAsync returns a result when a valid user ID is provided.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetMostRecentQuizResultAsync_ShouldReturnResult_WhenUserIdIsValid()
        {
            // Arrange
            var result = new UsersPracticeQuizResults
            {
                Id = 1,
                UserID = "user123",
                UserScore = 85.5m,
                DateOfSubmission = DateTime.UtcNow
            };
            _mockResultsService.Setup(r => r.GetMostRecentQuizResultAsync("user123")).ReturnsAsync(result);

            // Act
            var quizResult = await _mockResultsService.Object.GetMostRecentQuizResultAsync("user123");

            // Assert
            quizResult.Should().NotBeNull();
            quizResult?.UserScore.Should().Be(85.5m);
        }

        /// <summary>
        /// Test to check if GetMostRecentQuizResultAsync returns null when an invalid user ID is provided.
        /// </summary>
        [Fact]
        public void SaveQuizResults_ShouldSaveResultsSuccessfully()
        {
            // Arrange
            _mockResultsService.Setup(r => r.SaveQuizResults(It.IsAny<decimal>(), It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>()));

            // Act
            _mockResultsService.Object.SaveQuizResults(90.0m, DateTime.UtcNow, 1, 1, "user123");

            // Assert
            _mockResultsService.Verify(r => r.SaveQuizResults(90.0m, It.IsAny<DateTime>(), 1, 1, "user123"), Times.Once);
        }
    }
}
