using Microsoft.AspNetCore.Mvc;
using UltraNet.Application.Interfaces;

namespace UltraNet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoggingController : ControllerBase
{
    private readonly ILoggingService _loggingService;

    public LoggingController(ILoggingService loggingService)
    {
        _loggingService = loggingService;
    }

    [HttpGet("LogData")]
    public async Task<IActionResult> LogData()
    {
        var result = await _loggingService.GetLog();
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }
}