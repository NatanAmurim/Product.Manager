using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using ProductManager.Api.Infra.Authentication;
using ProductManager.Api.Presentation.Controllers.Contracts.Requests.Login;
using ProductManager.Api.Presentation.Controllers.Contracts.Responses;

namespace ProductManager.Api.Presentation.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(JwtTokenGenerator jwtTokenGenerator, ILogger<AuthController> logger) : ControllerBase
    {
        [HttpPost]
        [EnableRateLimiting("LoginPolicy")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            if (loginRequest.UserName == "admin" && loginRequest.Password == "123")
            {
                var token = jwtTokenGenerator.GenerateToken(loginRequest.UserName, "Admin");
                return Ok(new Response<dynamic>("Login Authorized", "", new { Token = token }));
            }
            else if (loginRequest.UserName == "user" && loginRequest.Password == "123")
            {
                var token = jwtTokenGenerator.GenerateToken(loginRequest.UserName, "User");
                return Ok(new Response<dynamic>("Login Authorized", "", new { Token = token }));
            }

            logger.LogWarning("Login Unauthorized {UserName}. UserName/Passaword Invalid.", loginRequest.UserName);
            return Unauthorized(new Response<string>("Login Unauthorized", "401", default));
        }

    }
}
