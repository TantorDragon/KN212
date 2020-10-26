using Bakery.Api.Services;
using Bakery.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;

namespace Bakery.Api.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [EnableCors("AllowAnyOrigin")]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost] 
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var tokenString = await _authService.GetToken(user.Login, user.Password);

            if (tokenString is null)
            {
                return BadRequest();
            }

            return Ok(new { Token = tokenString });
        }
    }
}
