using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    [Route("/api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly IRoleService _roleService;

        public AuthController(IAuthService userManager, IRoleService roleService)
        {
            _authService = userManager;
            _roleService = roleService; 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister model)
        {
            var result = await _authService.RegisterUserAsync(model);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            await _roleService.AssignRoleAsync(model.Email + model.Role);

            return Ok("L'utilisateur a été enregistré avec succès avec le rôle " + model.Role);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin model)
        {
            var tokenResponse = await _authService.AuthenticateUserAsync(model);

            if (tokenResponse == null)
            {
                return Unauthorized("Informations d'autentification invalide");
            }

            return Ok(tokenResponse);
        }


    }
}
