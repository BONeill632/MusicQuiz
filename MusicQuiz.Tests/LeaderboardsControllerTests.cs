using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MusicQuiz.Core.Entities;
using MusicQuiz.Web.Controllers;
using MusicQuiz.Web.Models.Leaderboards;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using MusicQuiz.Core.Migrations;

namespace MusicQuiz.Tests.Controllers
{
    public class LeaderboardsControllerTests
    {
        private readonly Mock<UserManager<UserData>> _mockUserManager;
        private readonly ApplicationDbContext _context;
        private readonly LeaderboardsController _controller;

        public LeaderboardsControllerTests()
        {
            _mockUserManager = new Mock<UserManager<UserData>>(
                Mock.Of<IUserStore<UserData>>(), null, null, null, null, null, null, null, null);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);

            _controller = new LeaderboardsController(_context, _mockUserManager.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                },
                ViewModel = new LeaderboardViewModel
                {
                    TopUsers = new List<UserData>(),
                    SelectedAcademicYear = string.Empty,
                    AcademicYearOptions = new List<string>()
                }
            };

            // Seed the database with test data
            _context.Users.AddRange(
                new UserData { IntID = 1, FirstName = "Admin", LastName = "User", EXP = 1000, AcademicYear = "22/23", StudentID = "12345678" },
                new UserData { IntID = 2, FirstName = "John", LastName = "Doe", EXP = 500, AcademicYear = "22/23", StudentID = "12345678" },
                new UserData { IntID = 3, FirstName = "Jane", LastName = "Smith", EXP = 300, AcademicYear = "22/23", StudentID = "12345678" }
            );
            _context.SaveChanges();
        }

        [Fact]
        public async Task Index_ShouldReturnViewResultWithViewModel()
        {
            // Act
            var result = await _controller.Index("22/23");

            // Assert
            result.Should().BeOfType<ViewResult>();
            var viewResult = result as ViewResult;
            var viewModel = viewResult?.Model as LeaderboardViewModel;

            viewModel.Should().NotBeNull();
            viewModel?.TopUsers.Should().HaveCount(2); // Exclude Admin
            viewModel?.SelectedAcademicYear.Should().Be("2022/23");
        }

        [Fact]
        public async Task IndexPost_ShouldCallIndexWithProvidedAcademicYear()
        {
            // Act
            var result = await _controller.IndexPost("22/23");

            // Assert
            result.Should().BeOfType<ViewResult>();
            var viewResult = result as ViewResult;
            var viewModel = viewResult?.Model as LeaderboardViewModel;

            viewModel.Should().NotBeNull();
            viewModel?.SelectedAcademicYear.Should().Be("2022/23");
        }
    }
}
