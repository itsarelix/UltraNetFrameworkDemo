using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UltraNet.Framework.Core.Interfaces.Otp;
using UltraNet.Framework.Core.Constants;
using UltraNet.Framework.Modules.Otp;
using UltraNet.Framework.Modules.Otp.Strategies;


namespace UltraNet.Framework.Core.Extensions;

public static class OtpServiceCollectionExtensions
{
    public static IServiceCollection AddUltraOtp(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<OtpOptions>(configuration.GetSection("OtpOptions"));

        services.AddScoped<IOTPStrategy, SmsOtpStrategy>();
        services.AddScoped<IOTPStrategy, EmailOtpStrategy>();
        services.AddScoped<IOTPService, OtpService>();
        services.AddScoped<ICacheService, CacheService>();


        return services;
    }
}
