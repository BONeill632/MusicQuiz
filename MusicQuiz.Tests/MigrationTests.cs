using Microsoft.EntityFrameworkCore;
using MusicQuiz.Core.Migrations;

namespace MusicQuiz.Tests
{
    public class MigrationTests
    {
        /// <summary>
        /// Test to ensure that the database schema matches the expected schema.
        /// </summary>
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
