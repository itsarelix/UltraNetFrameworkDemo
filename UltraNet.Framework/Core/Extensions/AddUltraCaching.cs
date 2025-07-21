using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UltraNet.Framework.Core.Interfaces.Caching;
using UltraNet.Framework.Modules.Caching;
using UltraNet.Framework.Modules.Caching.Factory;
using UltraNet.Framework.Modules.Caching.Providers;


namespace UltraNet.Framework.Core.Extensions;
public static class CachingServiceCollectionExtensions
{
    public static IServiceCollection AddUltraCaching(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMemoryCache();
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = configuration["Redis:Configuration"];
            options.InstanceName = configuration["Redis:InstanceName"];
        });

        services.AddScoped<MemoryCacheService>();
        services.AddScoped<RedisCacheProvider>();

        services.AddScoped<ICacheProviderFactory, CacheProviderFactory>();
        services.AddScoped<ICacheService, CacheService>();

        return services;
    }
}