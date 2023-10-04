using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using TestApplication.Api.Controllers;
using TestApplication.Application.Services.Users;
using TestApplication.Contracts.UserDetails;
using TestApplication.UnitTests.Fixtures;

namespace TestApplication.UnitTests.Systems.Controllers
{
    public class TestUserController
    {
        [Fact]
        public async Task Get_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange

            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            var sut = new UserController(mockUserService.Object);

            //Act

            var result = (OkObjectResult)await sut.Get();

            //Assert

            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesUserServiceExactlyOnce()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UserController(mockUserService.Object);

            //Act

            var result = await sut.Get();

            //Assert

            mockUserService.Verify(
                service => service.GetAllUsers(), 
                Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListofUsers()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(UsersFixture.GetTestUsers());

            var sut = new UserController(mockUserService.Object);

            //Act

            var result = await sut.Get();

            //Assert

            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.Value.Should().BeOfType<List<User>>();
        }

        [Fact]
        public async Task Get_OnNoUsersFound_Returns404()
        {
            //Arrange
            var mockUserService = new Mock<IUserService>();
            mockUserService
                .Setup(service => service.GetAllUsers())
                .ReturnsAsync(new List<User>());

            var sut = new UserController(mockUserService.Object);

            //Act

            var result = await sut.Get();

            //Assert

            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
    }
}