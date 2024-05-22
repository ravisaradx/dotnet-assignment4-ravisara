using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Jwt;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JWTtokens _jwt;

        public AuthController(JWTtokens jwt)
        {
            _jwt = jwt;
        }

        [HttpPost("User")]
        public IActionResult GenerateUserToken()
        {
            var token = _jwt.GenerateToken("user");
            return Ok(new { token });
        }

        [HttpPost("Admin")]
        public IActionResult GenerateAdminToken()
        {
            var token = _jwt.GenerateToken("admin");
            return Ok(new { token });
        }
    }
}
