using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UltraNet.Application.Common;
using UltraNet.Application.Common.Enum;
using UltraNet.Application.Interfaces;
using UltraNet.Application.Models;

namespace UltraNet.Infrastructure.Services
{
    public class CacheService : ICacheService
    {
        private readonly UltraNet.Framework.Core.Interfaces.Caching.ICacheService _cache;

        public CacheService(UltraNet.Framework.Core.Interfaces.Caching.ICacheService cache)
        {
            _cache = cache;
        }

        public async Task<ReturnData<string>> CacheData(CacheRequest request)
        {
            var key = $"product:{request.Key}";

            var cached = await _cache.GetAsync<string>(key);
            if (!string.IsNullOrEmpty(cached))
                return ReturnData<string>.Success(cached, "Value retrieved from cache.");

            var result = $"Product #{request.Key} [From database]";
            await _cache.SetAsync(key, result, TimeSpan.FromMinutes(1));

            return ReturnData<string>.Success(result, "Value retrieved from simulated database and cached.");
        }
    }
}
