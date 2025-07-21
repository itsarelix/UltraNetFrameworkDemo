using Microsoft.AspNetCore.Mvc;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;

namespace UltraNet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OtpController : ControllerBase
{
    private readonly IOtpService _otpService;

    public OtpController(IOtpService otpService)
    {
        _otpService = otpService;
    }

    [HttpPost("SendOtp")]
    public async Task<IActionResult> SendOtp(SendOtpRequest request)
    {
        var result = await _otpService.SendOtp(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }


    [HttpPost("VerifyOtp")]
    public async Task<IActionResult> VerifyOtp(VerifyOtpRequest request)
    {
        var result = await _otpService.VerifyOtp(request);
        return result.IsSuccess ? Ok(result) : BadRequest(result);
    }


}