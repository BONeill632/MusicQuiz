using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Moq;
using MusicQuiz.Core.Entities;
using MusicQuiz.Core.Migrations;
using MusicQuiz.Web.Controllers;
using MusicQuiz.Web.Models.Admin;
using MusicQuiz.Web.Models.Quiz;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace MusicQuiz.Tests.Controllers
{
    public class AdminControllerTests
    {
        private readonly Mock<UserManager<UserData>> _mockUserManager;
        private readonly Mock<RoleManager<IdentityRole>> _mockRoleManager;
        private readonly ApplicationDbContext _context;
        private readonly AdminController _controller;

        public AdminControllerTests()
        {
            _mockUserManager = new Mock<UserManager<UserData>>(
                Mock.Of<IUserStore<UserData>>(), null, null, null, null, null, null, null, null);

            _mockRoleManager = new Mock<RoleManager<IdentityRole>>(
                Mock.Of<IRoleStore<IdentityRole>>(), null, null, null, null);

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase45")
                .Options;

            _context = new ApplicationDbContext(options);

            _controller = new AdminController(_mockUserManager.Object, _mockRoleManager.Object, _context)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            // Configure TempData
            _controller.TempData = new Mock<ITempDataDictionary>().Object;
        }

        [Fact]
        public void Index_ShouldReturnViewResult()
        {
            // Act
            var result = _controller.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public async Task EditQuestion_Get_ShouldReturnQuestion()
        {
            // Arrange
            var musicFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Music");
            Directory.CreateDirectory(musicFolder);
            File.WriteAllText(Path.Combine(musicFolder, "sample-question.mp3"), "dummy content");
            File.WriteAllText(Path.Combine(musicFolder, "sample-reference.mp3"), "dummy content");

            var question = new QuizQuestion
            {
                Id = 1,
                TopicId = 1,
                DifficultyId = 1,
                Question = "Sample Question",
                CorrectAnswer = "A",
                WrongAnswerOne = "B",
                WrongAnswerTwo = "C",
                WrongAnswerThree = "D",
                QuestionMusicFilePath = "/Music/sample-question.mp3",
                ReferenceMusicFilePath = "/Music/sample-reference.mp3"
            };
            _context.QuizQuestions.Add(question);
            await _context.SaveChangesAsync();

            // Act
            var result = await _controller.EditQuestion(1);

            // Assert
            result.Should().BeOfType<ViewResult>();
            var viewResult = result as ViewResult;
            var model = viewResult?.Model as QuestionViewModel;
            model.Should().NotBeNull();
            model.QuestionID.Should().Be(1);
            model.Question.Should().Be("Sample Question");
            model.MusicQuestionFilePath.Should().Be("/Music/sample-question.mp3");
            model.MusicReferenceFilePath.Should().Be("/Music/sample-reference.mp3");

            // Cleanup
            Directory.Delete(musicFolder, true);
        }
    }
}
