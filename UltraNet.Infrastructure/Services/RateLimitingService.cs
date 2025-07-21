using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;
using UltraNet.Application.Common.Enum;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;
using UltraNet.Framework.Core.Interfaces.RateLimiting;

namespace UltraNet.Infrastructure.Services
{
    public class RateLimitingService : IRateLimitingService
    {
        private readonly IRateLimiter _rateLimiter;
        public RateLimitingService(IRateLimiter rateLimiter)
        {
            _rateLimiter = rateLimiter;    
        }

        public async Task<ReturnData<string>> ControlRateLimit(RateLimitRequest request)
        {
            var isAllowed = await _rateLimiter.IsRequestAllowedAsync(request.Key);

            if (isAllowed)
                return ReturnData<string>.Success("Request is allowed.");
            else
                return ReturnData<string>.Fail("Too many requests. Please try again later.");
        }
    }
}
