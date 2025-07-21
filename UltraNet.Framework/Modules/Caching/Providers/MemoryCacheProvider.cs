using Microsoft.Extensions.Caching.Memory;
using UltraNet.Framework.Core.Interfaces.Caching;

namespace UltraNet.Framework.Modules.Caching.Providers
{
    public class MemoryCacheService : ICacheProvider
    {
        private readonly IMemoryCache _cache;

        public MemoryCacheService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public Task<T?> GetAsync<T>(string key)
        {
            var success = _cache.TryGetValue(key, out T? value);
            return Task.FromResult(success ? value : default);
        }

        public Task SetAsync<T>(string key, T value, TimeSpan? expiration = null)
        {
            var options = new MemoryCacheEntryOptions();
            if (expiration.HasValue)
                options.SetAbsoluteExpiration(expiration.Value);

            _cache.Set(key, value, options);
            return Task.CompletedTask;
        }

        public Task RemoveAsync(string key)
        {
            _cache.Remove(key);
            return Task.CompletedTask;
        }
    }
}
