using FluentAssertions;
using Microsoft.Extensions.Options;
using Moq;
using Moq.Protected;
using TestApplication.Application.Services.Users;
using TestApplication.Contracts.Config;
using TestApplication.Contracts.UserDetails;
using TestApplication.UnitTests.Fixtures;
using TestApplication.UnitTests.Helpers;

namespace TestApplication.UnitTests.Systems.Services
{
    public class TestUserService
    {
        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesHttpGetRequest()
        {
            //Arrange

            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>
                .SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UserApiOptions
            {
                EndPoint = "https://test.com/users"
            });
            var sut = new UserService(httpClient,config);

            //Act

            await sut.GetAllUsers();

            //Assert

            handlerMock
                .Protected()
                .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken> ());
        }

        [Fact]
        public async Task GetAllUsers_WhenHits404_ReturnsEmptyListofUsers()
        {
            //Arrange

            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.SetUpRetun404();
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UserApiOptions
            {
                EndPoint = "https://test.com/users"
            });
            var sut = new UserService(httpClient, config);

            //Act

            var result =await sut.GetAllUsers();

            //Assert

            result.Count.Should().Be(0);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_ReturnsListofUsersofExpectedSize()
        {
            //Arrange

            var expectedResponse = UsersFixture.GetTestUsers();
            var handlerMock = MockHttpMessageHandler<User>.
                SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UserApiOptions
            {
                EndPoint = "https://test.com/users"
            });
            var sut = new UserService(httpClient, config);

            //Act

            var result = await sut.GetAllUsers();

            //Assert

            result.Count.Should().Be(expectedResponse.Count);
        }

        [Fact]
        public async Task GetAllUsers_WhenCalled_InvokesConfiguredExternalUrl()
        {
            //Arrange

            var expectedResponse = UsersFixture.GetTestUsers();
            var endpoint = "https://test.com/users";
            var handlerMock = MockHttpMessageHandler<User>.
                SetupBasicGetResourceList(expectedResponse, endpoint);
            var httpClient = new HttpClient(handlerMock.Object);

            var config = Options.Create(new UserApiOptions
            {
                EndPoint = "https://test.com/users"
            });

            var sut = new UserService(httpClient,config);

            //Act

            var result = await sut.GetAllUsers();

            //Assert

            handlerMock
                .Protected()
                .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => 
                req.Method == HttpMethod.Get && 
                req.RequestUri.ToString() == endpoint),
                ItExpr.IsAny<CancellationToken>());
        }
    }
}
