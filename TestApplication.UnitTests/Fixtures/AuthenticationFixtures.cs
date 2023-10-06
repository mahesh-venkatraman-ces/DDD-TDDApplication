using TestApplication.Application.Services.Authentication;
using TestApplication.Contracts.Authentication;
using TestApplication.Contracts.UserDetails;

namespace TestApplication.UnitTests.Fixtures
{
    public static class AuthenticationFixtures
    {
        public static AuthenticationResult GetAuthenticationResult() =>
                    new AuthenticationResult()
                    {
                        Id = Guid.NewGuid(),
                        FirstName = "Test",
                        LastName = "User",
                        Email = "test.user.1@test.com",
                        Token = "token"
                    };

        public static RegisterRequest GetRegisterResult() =>
                    new RegisterRequest()
                    {
                        FirstName = "Test",
                        LastName = "User",
                        Email = "test.user.1@test.com",
                        Password = "password"
                    };

        public static LoginRequest GetLoginResult() =>
                    new LoginRequest()
                    {
                        Email = "test.user.1@test.com",
                        Password = "password"
                    };
    }
}
