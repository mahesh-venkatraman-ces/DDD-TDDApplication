using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApplication.Api.Controllers;
using TestApplication.Application.Services.Authentication;
using TestApplication.Application.Services.Users;
using TestApplication.Contracts.Authentication;
using TestApplication.Contracts.UserDetails;
using TestApplication.UnitTests.Fixtures;

namespace TestApplication.UnitTests.Systems.Controllers
{
    public class TestAuthenticationController
    {
        [Fact]
        public void Get_OnRegisterationSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockUserService = new Mock<IAuthenticationService>();
            var request = AuthenticationFixtures.GetRegisterResult();
            var regRequest = AuthenticationFixtures.GetAuthenticationResult();

            mockUserService
                .Setup(service => 
                service.Register(regRequest.FirstName, regRequest.LastName, 
                regRequest.Email, regRequest.Token))
                .Returns(AuthenticationFixtures.GetAuthenticationResult());

            var sut = new AuthenticationController(mockUserService.Object);

            //Act

            var result = (OkObjectResult)sut.Register(request);

            //Assert

            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void Get_OnLoginSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockUserService = new Mock<IAuthenticationService>();
            var request = AuthenticationFixtures.GetLoginResult();
            var regRequest = AuthenticationFixtures.GetAuthenticationResult();

            mockUserService
                .Setup(service =>
                service.Login(regRequest.Email, regRequest.Token))
                .Returns(AuthenticationFixtures.GetAuthenticationResult());

            var sut = new AuthenticationController(mockUserService.Object);

            //Act

            var result = (OkObjectResult)sut.Login(request);

            //Assert

            Assert.Equal(200, result.StatusCode);
        }
    }
}
