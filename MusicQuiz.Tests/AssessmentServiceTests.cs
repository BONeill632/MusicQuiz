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
