using Microsoft.AspNetCore.Mvc;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;


namespace UltraNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var result = await _authService.Register(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var token = await _authService.Login(request);
            return Ok(token);
        }

        [HttpGet("CheckToken")]
        public IActionResult CheckToken()
        {
            var token = Request.Headers["Authorization"].ToString();
            return Ok(new { token });
        }
        
    }
}