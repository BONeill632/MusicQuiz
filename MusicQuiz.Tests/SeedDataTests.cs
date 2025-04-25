using FluentAssertions;
using Microsoft.AspNetCore.Identity;
using Moq;
using MusicQuiz.Core.Data;
using MusicQuiz.Core.Entities;
using Xunit;

namespace MusicQuiz.Tests
{
    public class SeedDataTests
    {
        [Fact]
        public async Task SeedUserData_ShouldCreateAdminAndNotLoggedInUsers()
        {
            // Arrange
            var mockUserStore = new Mock<IUserStore<UserData>>();
            var mockUserManager = new Mock<UserManager<UserData>>(
                mockUserStore.Object, null, null, null, null, null, null, null, null);

            var mockRoleStore = new Mock<IRoleStore<IdentityRole>>();
            var mockRoleManager = new Mock<RoleManager<IdentityRole>>(
                mockRoleStore.Object, null, null, null, null);

            // Mock role creation
            mockRoleManager.Setup(r => r.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync((IdentityRole)null);
            mockRoleManager.Setup(r => r.CreateAsync(It.IsAny<IdentityRole>()))
                .ReturnsAsync(IdentityResult.Success);

            // Mock user creation
            mockUserManager.Setup(u => u.FindByEmailAsync(It.IsAny<string>()))
                .ReturnsAsync((UserData)null);
            mockUserManager.Setup(u => u.CreateAsync(It.IsAny<UserData>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);
            mockUserManager.Setup(u => u.AddToRoleAsync(It.IsAny<UserData>(), It.IsAny<string>()))
                .ReturnsAsync(IdentityResult.Success);

            // Act
            await AccountSeedData.SeedUserData(mockUserManager.Object, mockRoleManager.Object);

            // Assert
            mockRoleManager.Verify(r => r.CreateAsync(It.Is<IdentityRole>(role => role.Name == "Admin")), Times.Once);
            mockRoleManager.Verify(r => r.CreateAsync(It.Is<IdentityRole>(role => role.Name == "User")), Times.Once);

            mockUserManager.Verify(u => u.CreateAsync(It.Is<UserData>(user => user.Email == "admin@admin.com"), "Admin@123"), Times.Once);
            mockUserManager.Verify(u => u.CreateAsync(It.Is<UserData>(user => user.Email == "notloggedin@notloggedin.com"), "Password@123"), Times.Once);

            mockUserManager.Verify(u => u.AddToRoleAsync(It.Is<UserData>(user => user.Email == "admin@admin.com"), "Admin"), Times.Once);
            mockUserManager.Verify(u => u.AddToRoleAsync(It.Is<UserData>(user => user.Email == "notloggedin@notloggedin.com"), "User"), Times.Once);
        }
    }
}
