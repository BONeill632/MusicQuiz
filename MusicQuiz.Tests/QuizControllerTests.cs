using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Web.Controllers;
using MusicQuiz.Web.Models.Home;
using MusicQuiz.Web.Models.Quiz;
using Microsoft.AspNetCore.Identity;
using MusicQuiz.Core.Migrations;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace MusicQuiz.Tests
{
    public class QuizControllerTests
    {
        private readonly Mock<IResultsService> _mockResultsService;
        private readonly Mock<UserManager<UserData>> _mockUserManager;
        private readonly ApplicationDbContext _context;
        private readonly QuizController _controller;

        public QuizControllerTests()
        {
            _mockResultsService = new Mock<IResultsService>();
            _mockUserManager = new Mock<UserManager<UserData>>(
                Mock.Of<IUserStore<UserData>>(), null, null, null, null, null, null, null, null);

            // Generate a unique database name for each test
            var uniqueDatabaseName = Guid.NewGuid().ToString();

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: uniqueDatabaseName)
                .Options;

            _context = new ApplicationDbContext(options);

            _controller = new QuizController(_context, _mockResultsService.Object, _mockUserManager.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            _controller.ControllerContext.HttpContext.Session = new MockHttpSession();
            _controller.TempData = new TempDataDictionary(
                _controller.ControllerContext.HttpContext,
                Mock.Of<ITempDataProvider>()
            );

            // Seed the database with all required properties
            _context.QuizQuestions.Add(new QuizQuestion
            {
                Id = 1,
                TopicId = 1,
                DifficultyId = 1,
                Question = "Sample Question",
                CorrectAnswer = "Answer",
                WrongAnswerOne = "Wrong Answer 1",
                WrongAnswerTwo = "Wrong Answer 2",
                WrongAnswerThree = "Wrong Answer 3",
                QuestionMusicFilePath = "path/to/question/music.mp3",
                ReferenceMusicFilePath = "path/to/reference/music.mp3"
            });
            _context.SaveChanges();
        }

        /// <summary>
        /// Test to ensure that the Index action clears the session and returns a ViewResult with a MusicQuizViewModel.
        /// </summary>
        [Fact]
        public void Index_ShouldClearSessionAndReturnView()
        {
            // Act
            var result = _controller.Index();

            // Assert
            _controller.HttpContext.Session.Keys.Should().BeEmpty();
            result.Should().BeOfType<ViewResult>();
            var viewResult = result as ViewResult;
            viewResult?.Model.Should().BeOfType<MusicQuizViewModel>();
        }

        /// <summary>
        /// Test to ensure that the SelectTopic action stores the selected topic in TempData and redirects to the SelectDifficulty action.
        /// </summary>
        [Fact]
        public void SelectDifficulty_ShouldStoreTopicAndRedirect()
        {
            // Act
            var result = _controller.SelectDifficulty("Pop");

            // Assert
            _controller.TempData["SelectedTopic"].Should().Be("Pop");
            result.Should().BeOfType<RedirectToActionResult>();
            var redirectResult = result as RedirectToActionResult;
            redirectResult?.ActionName.Should().Be("SelectDifficulty");
        }

        /// <summary>
        /// Test to ensure that the SelectDifficulty action returns a BadRequestObjectResult when the topic is invalid.
        /// </summary>
        [Fact]
        public void SelectDifficulty_ShouldReturnBadRequest_WhenTopicIsInvalid()
        {
            // Arrange
            _controller.TempData["SelectedTopic"] = "InvalidTopic";

            // Act
            var result = _controller.SelectDifficulty(new MusicQuizViewModel());

            // Assert
            result.Should().BeOfType<BadRequestObjectResult>();
        }

        /// <summary>
        /// Test to ensure that the SelectDifficulty action returns a ViewResult with a MusicQuizViewModel.
        /// </summary>
        [Fact]
        public void ShowQuestion_ShouldReturnViewWithQuestion()
        {
            // Arrange
            var questions = new List<QuestionViewModel>
            {
                new() { Question = "Sample Question" }
            };
            _controller.HttpContext.Session.SetString("QuizQuestions", JsonSerializer.Serialize(questions));
            _controller.HttpContext.Session.SetInt32("CurrentQuestionIndex", 0);

            // Act
            var result = _controller.ShowQuestion();

            // Assert
            result.Should().BeOfType<ViewResult>();
            var viewResult = result as ViewResult;
            var model = viewResult?.Model as QuestionViewModel;
            model?.Question.Should().Be("Sample Question");
        }
    }
}
