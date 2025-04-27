using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Web.Controllers;
using MusicQuiz.Web.Models.Assessment;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;
using MusicQuiz.Web.Models.Quiz;
using MusicQuiz.Core.Migrations;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MusicQuiz.Tests.Controllers
{
    public class AssessmentControllerTests
    {
        private readonly Mock<UserManager<UserData>> _mockUserManager;
        private readonly Mock<IResultsService> _mockResultsService;
        private readonly Mock<IAssessmentService> _mockAssessmentService;
        private readonly ApplicationDbContext _context;
        private readonly AssessmentController _controller;

        public AssessmentControllerTests()
        {
            _mockUserManager = new Mock<UserManager<UserData>>(
                Mock.Of<IUserStore<UserData>>(), null, null, null, null, null, null, null, null);

            _mockResultsService = new Mock<IResultsService>();
            _mockAssessmentService = new Mock<IAssessmentService>();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseAgain")
                .Options;

            _context = new ApplicationDbContext(options);

            _controller = new AssessmentController(_context, _mockUserManager.Object, _mockResultsService.Object, _mockAssessmentService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            // Configure session
            _controller.ControllerContext.HttpContext.Session = new MockHttpSession();
        }
        [Fact]
        public async Task Index_ShouldReturnViewWithAssessments()
        {
            // Arrange
            var user = new UserData
            {
                Id = "1",
                UserName = "TestUser",
                AcademicYear = "22/23",
                FirstName = "John",
                LastName = "Doe",
                StudentID = "12345678"
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            _mockUserManager.Setup(m => m.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                .ReturnsAsync(user);
            _mockUserManager.Setup(m => m.IsEmailConfirmedAsync(user)).ReturnsAsync(true);

            var claims = new[]
            {
                new System.Security.Claims.Claim(System.Security.Claims.ClaimTypes.Name, "TestUser")
            };

            var identity = new System.Security.Claims.ClaimsIdentity(claims, "TestAuthType");
            var principal = new System.Security.Claims.ClaimsPrincipal(identity);

            _controller.ControllerContext.HttpContext.User = principal;

            _context.Assessments.Add(new Assessments
            {
                ID = 1,
                AcademicYear = "22/23",
                OpenFrom = DateTime.Now.AddDays(-1),
                OpenTo = DateTime.Now.AddDays(1),
                TopicId = 1
            });
            _context.SaveChanges();

            // Act
            var result = await _controller.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
            var viewResult = result as ViewResult;
            var model = viewResult?.Model as List<AssessmentViewModel>;
            model.Should().NotBeNull();
            model.Should().HaveCount(1);
            model[0].IsUnlocked.Should().BeTrue();
        }


        [Fact]
        public async Task StartAssessment_ShouldRedirectIfUserNotVerified()
        {
            // Arrange
            var user = new UserData
            {
                Id = "1",
                AcademicYear = "22/23",
                FirstName = "John",
                LastName = "Doe",
                StudentID = "12345678"
            };

            _mockUserManager.Setup(m => m.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                .ReturnsAsync(user);
            _mockUserManager.Setup(m => m.IsEmailConfirmedAsync(user)).ReturnsAsync(false);

            // Set up TempData
            var tempData = new Mock<ITempDataDictionary>();
            _controller.TempData = tempData.Object;

            // Act
            var result = await _controller.StartAssessment(1);

            // Assert
            result.Should().BeOfType<RedirectToActionResult>();
            var redirectResult = result as RedirectToActionResult;
            redirectResult?.ActionName.Should().Be("Index");
            tempData.VerifySet(t => t["ErrorMessage"] = "You must verify your email address before accessing assessments. Please check your email for a verification link.", Times.Once);
        }

        [Fact]
        public async Task StartAssessment_ShouldRedirectIfAssessmentNotFound()
        {
            // Arrange
            var user = new UserData
            {
                Id = "1",
                AcademicYear = "22/23",
                FirstName = "John",
                LastName = "Doe",
                StudentID = "12345678"
            };

            _mockUserManager.Setup(m => m.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                .ReturnsAsync(user);
            _mockUserManager.Setup(m => m.IsEmailConfirmedAsync(user)).ReturnsAsync(true);

            // Set up TempData
            var tempData = new Mock<ITempDataDictionary>();
            _controller.TempData = tempData.Object;

            // Act
            var result = await _controller.StartAssessment(999);

            // Assert
            result.Should().BeOfType<RedirectToActionResult>();
            var redirectResult = result as RedirectToActionResult;
            redirectResult?.ActionName.Should().Be("Index");
            tempData.VerifySet(t => t["ErrorMessage"] = "You cannot start this assessment at this time.", Times.Once);
        }

        [Fact]
        public async Task QuizFinished_ShouldSaveResultsAndReturnView()
        {
            // Arrange
            var user = new UserData
            {
                Id = "1",
                AcademicYear = "22/23",
                FirstName = "John",
                LastName = "Doe",
                StudentID = "12345678"
            };

            _mockUserManager.Setup(m => m.GetUserAsync(It.IsAny<System.Security.Claims.ClaimsPrincipal>()))
                .ReturnsAsync(user);

            _mockAssessmentService.Setup(m => m.GetAssessmentByIdAsync(1))
                .ReturnsAsync(new Assessments
                {
                    ID = 1,
                    TopicId = 1,
                    AcademicYear = "23/24",
                    OpenFrom = DateTime.Now,
                    OpenTo = DateTime.Now.AddDays(1)
                });

            _controller.HttpContext.Session.SetInt32("AssessmentID", 1);
            _controller.HttpContext.Session.SetString("QuizQuestions", JsonSerializer.Serialize(new List<QuestionViewModel>
            {
                new QuestionViewModel { CorrectAnswer = "A", UserAnswer = "A" },
                new QuestionViewModel { CorrectAnswer = "B", UserAnswer = "C" }
            }));

            // Act
            var result = await _controller.QuizFinished();

            // Assert
            result.Should().BeOfType<ViewResult>();
            _mockResultsService.Verify(m => m.SaveAssessmentResults(50, It.IsAny<DateTime>(), 3, 1, "1", 1), Times.Once);
        }
    }
}
