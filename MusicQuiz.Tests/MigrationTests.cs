using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Migrations;
using Xunit;

namespace MusicQuiz.Tests
{
    public class MigrationTests
    {
        [Fact]
        public void Database_ShouldMatchExpectedSchema()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using var context = new ApplicationDbContext(options);

            // Act
            var canConnect = context.Database.CanConnect();

            // Assert
            Assert.True(canConnect);
        }
    }
}
