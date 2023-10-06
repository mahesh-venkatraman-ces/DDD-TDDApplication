﻿using Microsoft.AspNetCore.Mvc;
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
                Id = authResult.Id,
                FirstName = authResult.FirstName,
                LastName = authResult.LastName,
                Email = authResult.Email,
                Token = authResult.Token
            };
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authenticationService.Login(request.Email, request.Password);
            var response = new AuthenticationResponse()
            {
                Id = authResult.Id,
                Email = authResult.Email,
                Token = authResult.Token
            };
            return Ok(response);
        }
    }
}
