using FluentAssertions;
using MusicQuiz.Core.Entities;
using Xunit;

namespace MusicQuiz.Tests
{
    public class UserDataTests
    {
        [Fact]
        public void GetLevel_ShouldReturnCorrectLevelBasedOnExp()
        {
            // Arrange
            var user = new UserData { EXP = 150, AcademicYear = "23/24" , FirstName = "test", LastName = "test", StudentID = "12345678" };

            // Act
            var level = user.GetLevel();

            // Assert
            level.Should().Be(1);
        }

        [Fact]
        public void GetLevel_ShouldReturnMaxLevel_WhenExpExceedsMaxThreshold()
        {
            // Arrange
            var user = new UserData { EXP = 10000, AcademicYear = "23/24", FirstName = "test", LastName = "test" , StudentID = "12345678" };

            // Act
            var level = user.GetLevel();

            // Assert
            level.Should().Be(5);
        }
    }
}
