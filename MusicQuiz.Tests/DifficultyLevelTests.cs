using FluentAssertions;
using MusicQuiz.Core.Enums;
using Xunit;

namespace MusicQuiz.Tests
{
    public class DifficultyLevelTests
    {
        /// <summary>
        /// Test to check if the DifficultyLevel enum has the expected values.
        /// </summary>
        [Fact]
        public void DifficultyLevel_ShouldHaveExpectedValues()
        {
            // Assert
            ((int)DifficultyLevel.Easy).Should().Be(1);
            ((int)DifficultyLevel.Medium).Should().Be(2);
            ((int)DifficultyLevel.Hard).Should().Be(3);
        }
    }
}
