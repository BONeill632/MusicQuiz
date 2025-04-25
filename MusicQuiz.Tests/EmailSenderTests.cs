using Moq;
using MusicQuiz.Application.Interfaces;
using System.Threading.Tasks;
using Xunit;

namespace MusicQuiz.Tests
{
    public class EmailSenderTests
    {
        private readonly Mock<IEmailSender> _mockEmailSender;

        public EmailSenderTests()
        {
            _mockEmailSender = new Mock<IEmailSender>();
        }

        [Fact]
        public async Task SendEmailAsync_ShouldSendEmailSuccessfully()
        {
            // Arrange
            _mockEmailSender
                .Setup(e => e.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.CompletedTask);

            // Act
            await _mockEmailSender.Object.SendEmailAsync("test@example.com", "Subject", "Body");

            // Assert
            _mockEmailSender.Verify(
                e => e.SendEmailAsync("test@example.com", "Subject", "Body"),
                Times.Once
            );
        }
    }
}
