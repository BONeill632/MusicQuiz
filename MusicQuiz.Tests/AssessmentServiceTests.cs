using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Application.Services;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;
using Xunit;

namespace MusicQuiz.Tests
{
    public class AssessmentServiceTests
    {
        private readonly AssessmentService _assessmentService;
        private readonly ApplicationDbContext _context;

        public AssessmentServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _assessmentService = new AssessmentService(_context);
        }

        /// <summary>
        /// Test to check if the assessment is returned when a valid ID is provided
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAssessmentByIdAsync_ShouldReturnAssessment_WhenIdIsValid()
        {
            // Arrange
            var assessment = new Assessments
            {
                ID = 1,
                AcademicYear = "24/25",
                OpenFrom = DateTime.Now,
                OpenTo = DateTime.Now.AddDays(1)
            };
            _context.Assessments.Add(assessment);
            await _context.SaveChangesAsync();

            // Act
            var result = await _assessmentService.GetAssessmentByIdAsync(1);

            // Assert
            result.Should().NotBeNull();
            result?.AcademicYear.Should().Be("24/25");
        }

        /// <summary>
        /// Test to check if null is returned when an invalid ID is provided
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAssessmentByIdAsync_ShouldReturnNull_WhenIdIsInvalid()
        {
            // Act
            var result = await _assessmentService.GetAssessmentByIdAsync(-1);

            // Assert
            result.Should().BeNull();
        }
    }
}
