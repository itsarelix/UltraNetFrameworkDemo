using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;
using UltraNet.Framework.Core.Interfaces.Caching;

namespace UltraNet.Framework.Modules.Caching.Providers
{
    public class RedisCacheProvider : ICacheProvider
    {
        private readonly IDistributedCache _redis;
        public RedisCacheProvider(IDistributedCache redis)
        {
            _redis = redis;
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var json = await _redis.GetStringAsync(key);
            return json != null ? JsonSerializer.Deserialize<T>(json) : default;
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var options = new DistributedCacheEntryOptions();
            if (expiration.HasValue)
                options.SetAbsoluteExpiration(expiration.Value);

            var json = JsonSerializer.Serialize(value);
            await _redis.SetStringAsync(key, json, options);
        }

        public Task RemoveAsync(string key)
        {
            return _redis.RemoveAsync(key);
        }
    }
}
