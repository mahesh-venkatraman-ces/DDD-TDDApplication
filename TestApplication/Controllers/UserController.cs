using Microsoft.AspNetCore.Mvc;
using TestApplication.Application.Services.Users;

namespace TestApplication.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(Name = "GetUsers")]
        public async Task<IActionResult> Get()
        {
            var users = await _userService.GetAllUsers();

            if (users.Any())
            {
                return Ok(users);
            }
            return NotFound();
        }
    }
}