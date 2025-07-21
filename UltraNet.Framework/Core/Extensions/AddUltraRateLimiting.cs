using Microsoft.Extensions.DependencyInjection;
using UltraNet.Framework.Core.Interfaces.RateLimiting;
using UltraNet.Framework.Modules.RateLimiting;
using UltraNet.Framework.Modules.RateLimiting.Strategies;

namespace UltraNet.Framework.Core.Extensions;
public static class RateLimitingServiceCollectionExtensions
{
    public static IServiceCollection AddUltraRateLimiting(this IServiceCollection services)
    {
        services.AddSingleton<IRateLimitStrategy, InMemoryTokenBucket>();
        services.AddScoped<IRateLimiter, RateLimiter>();
        return services;
    }
}
