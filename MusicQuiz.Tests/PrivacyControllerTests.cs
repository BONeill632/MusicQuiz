using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using MusicQuiz.Web.Controllers;
using Xunit;

namespace MusicQuiz.Tests.Controllers
{
    public class PrivacyControllerTests
    {
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
