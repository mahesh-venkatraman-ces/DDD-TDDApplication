using Microsoft.AspNetCore.Mvc;
using TestApplication.Contracts.Authentication;
using TestApplication.Application.Services.Authentication;

namespace TestApplication.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authenticationService.Register(request.FirstName, request.LastName,
                request.Email, request.Password);
            var response = new AuthenticationResponse()
            {
                Id = Guid.NewGuid(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Token = "token"
            };
            return Ok(request);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse()
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                Token = "token"
            };
            return Ok(request);
        }
    }
}
