using UltraNet.Framework.Core.Interfaces.Caching;
using UltraNet.Framework.Modules.Caching.Providers;

namespace UltraNet.Framework.Modules.Caching.Factory
{
    public class CacheProviderFactory : ICacheProviderFactory
    {
        private readonly MemoryCacheService _memory;
        private readonly RedisCacheProvider _redis;

        public CacheProviderFactory(MemoryCacheService memory, RedisCacheProvider redis)
        {
            _memory = memory;
            _redis = redis;
        }

        public ICacheProvider GetProvider(string name)
        {
            return name.ToLower() switch
            {
                "memory" => _memory,
                "redis" => _redis,
                _ => _memory
            };
        }
    }
}
