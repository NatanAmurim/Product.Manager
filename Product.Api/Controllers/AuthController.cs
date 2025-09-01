using Microsoft.AspNetCore.Mvc;
using ProductManager.Api.Controllers.Contracts.Requests.Login;
using ProductManager.Api.Controllers.Contracts.Responses;
using ProductManager.Api.Infra.Authentication;

namespace ProductManager.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(JwtTokenGenerator jwtTokenGenerator): ControllerBase
    {
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest) 
        {
            if (loginRequest.UserName == "admin" && loginRequest.Password == "123")
            {
                var token = jwtTokenGenerator.GenerateToken(loginRequest.UserName, "Admin");
                return Ok(new Response<dynamic>("Login Unauthorized", "", new { Token = token }));
            }
            else if (loginRequest.UserName == "user" && loginRequest.Password == "123")
            {
                var token = jwtTokenGenerator.GenerateToken(loginRequest.UserName, "User");
                return Ok(new Response<dynamic>("Login Unauthorized", "", new {Token = token}));
            }

            return Unauthorized(new Response<string>("Login Unauthorized", "401", default));
        }

    }
}
