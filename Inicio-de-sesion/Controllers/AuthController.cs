using Inicio_de_sesion.DTOs;
using Inicio_de_sesion.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inicio_de_sesion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthenticatedUserDto>> Login(UserLoginDto userLoginDto)
        {
            var authenticatedUser = await _authService.AuthenticateAsync(userLoginDto);

            if (authenticatedUser == null)
                return Unauthorized();

            return Ok(authenticatedUser);
        }

        [HttpPost("register")]
        public async Task<ActionResult<AuthenticatedUserDto>> Register(UserRegisterDto userRegisterDto)
        {
            var newUser = await _authService.RegisterAsync(userRegisterDto);

            if (newUser == null)
                return BadRequest("Username or email already exists.");

            return Ok(newUser);
        }
    }
}
