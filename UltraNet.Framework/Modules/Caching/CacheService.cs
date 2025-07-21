using Microsoft.Extensions.Configuration;
using UltraNet.Framework.Core.Interfaces.Caching;
using UltraNet.Framework.Modules.Caching.Providers;

namespace UltraNet.Framework.Modules.Caching
{
    public class CacheService : ICacheService
    {
        private readonly ICacheProvider _provider;

        public CacheService(ICacheProviderFactory factory,IConfiguration configuration)
        {
            var type = configuration["Cache:Type"] ?? "memory";
            _provider = factory.GetProvider(type);
        }

        public async Task<T?> GetAsync<T>(string key)
        {
            var value = await _provider.GetAsync<T>(key);
            if (value != null)
                return value;        
            return value;
        }

        public async Task RemoveAsync(string key)
        {
            await _provider.RemoveAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            await _provider.SetAsync(key, value, expiry);
        }
    }
}
