using Microsoft.AspNetCore.Mvc;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;

namespace UltraNet.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CacheController : ControllerBase
    {
        private readonly ICacheService _cacheService;

        public CacheController(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        [HttpPost("GetFromCache")]
        public async Task<IActionResult> GetFromCache(CacheRequest request)
        {
            var result = await _cacheService.CacheData(request);
            return result.IsSuccess ? Ok(result) : BadRequest(result);  
        }
    }
}