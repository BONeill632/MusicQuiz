using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MusicQuiz.Application.Interfaces;
using MusicQuiz.Core.Entities;
using MusicQuiz.Web.Controllers;
using MusicQuiz.Web.Models.Home;
using MusicQuiz.Web.Models;
using System.Threading.Tasks;
using Xunit;

namespace MusicQuiz.Tests.Controllers
{
    public class HomeControllerTests
    {
        private readonly Mock<UserManager<UserData>> _mockUserManager;
        private readonly Mock<IResultsService> _mockResultsService;
        private readonly HomeController _controller;

        public HomeControllerTests()
        {
            _mockUserManager = new Mock<UserManager<UserData>>(
                Mock.Of<IUserStore<UserData>>(), null, null, null, null, null, null, null, null);

            _mockResultsService = new Mock<IResultsService>();

            _controller = new HomeController(_mockUserManager.Object, _mockResultsService.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
        }

        [Fact]
        public async Task Index_ShouldClearSessionAndReturnViewWithModel()
        {
            // Arrange
            _controller.HttpContext.Session = new MockHttpSession();

            // Act
            var result = await _controller.Index();

            // Assert
            _controller.HttpContext.Session.Keys.Should().BeEmpty();
            result.Should().BeOfType<ViewResult>();
            var viewResult = result as ViewResult;
            var model = viewResult?.Model as MusicQuizViewModel;
            model.Should().NotBeNull();
        }

        [Fact]
        public void Error_ShouldReturnViewWithErrorViewModel()
        {
            // Act
            var result = _controller.Error();

            // Assert
            result.Should().BeOfType<ViewResult>();
            var viewResult = result as ViewResult;
            var model = viewResult?.Model as ErrorViewModel;
            model.Should().NotBeNull();
            model?.RequestId.Should().NotBeNullOrEmpty();
        }
    }
}
