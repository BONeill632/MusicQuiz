using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Web.Controllers;

namespace MusicQuiz.Tests
{
    public class PrivacyControllerTests
    {
        /// <summary>
        /// Test to ensure that the Index action returns a ViewResult.
        /// </summary>
        [Fact]
        public void Index_ShouldReturnViewResult()
        {
            // Arrange
            var controller = new PrivacyController();

            // Act
            var result = controller.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }
    }
}
