using FluentAssertions;
using MusicQuiz.Core.Entities;

namespace MusicQuiz.Tests
{
    public class UserDataTests
    {
        /// <summary>
        /// Test to check if GetLevel returns the correct level based on the EXP value.
        /// </summary>
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

        /// <summary>
        /// Test to check if GetLevel returns the correct level when EXP is at the threshold for level 2.
        /// </summary>
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
