using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SmartInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ApiControllerBase
    {
        [HttpPost("register")]
        public async Task<IActionResult> Register()
        {
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login()
        {
            return Ok("User login successfully");
        }

        [HttpGet("me")]
        public IActionResult GetCurrentUser()
        {
            return Ok("Current user details");
        }
    }
}
