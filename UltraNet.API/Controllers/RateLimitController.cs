using Microsoft.AspNetCore.Mvc;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;

namespace UltraNet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RateLimitController : ControllerBase
{
    private readonly IRateLimitingService _rateLimitingService;

    public RateLimitController(IRateLimitingService rateLimitingService)
    {
        _rateLimitingService = rateLimitingService;
    }

    [HttpPost("CheckRateLimit")]
    public async Task<IActionResult> CheckRateLimit( RateLimitRequest request)
    {
        var result = await _rateLimitingService.ControlRateLimit(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);        
    }
}