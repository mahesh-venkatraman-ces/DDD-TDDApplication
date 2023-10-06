using FluentAssertions;
using Microsoft.Extensions.Options;
using TestApplication.Application.Services.Authentication;
using TestApplication.Application.Services.Users;
using TestApplication.Contracts.Config;
using TestApplication.Contracts.UserDetails;
using TestApplication.UnitTests.Fixtures;
using TestApplication.UnitTests.Helpers;

namespace TestApplication.UnitTests.Systems.Services
{
    public class TestAuthenticationService
    {
        [Fact]
        public async Task Get_RegisteredWithTestData_ThenOk()
        {
            //Arrange

            var expectedResponse = AuthenticationFixtures.GetAuthenticationResult();
            var request = AuthenticationFixtures.GetRegisterResult();

            var sut = new AuthenticationService();

            //Act

            var result =
                sut.Register(request.FirstName,request.LastName,request.Email,request.Password);

            //Assert

            Assert.IsType<AuthenticationResult>(result);
        }

        [Fact]
        public async Task Get_LoginWithTestData_ThenOk()
        {
            //Arrange

            var expectedResponse = AuthenticationFixtures.GetAuthenticationResult();
            var request = AuthenticationFixtures.GetLoginResult();

            var sut = new AuthenticationService();

            //Act

            var result =
                sut.Login(request.Email, request.Password);

            //Assert

            Assert.IsType<AuthenticationResult>(result);
        }
    }
}
