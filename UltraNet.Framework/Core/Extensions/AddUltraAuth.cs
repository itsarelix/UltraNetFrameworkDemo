using Microsoft.Extensions.DependencyInjection;
using UltraNet.Framework.Core.Interfaces.JWT;
using UltraNet.Framework.Core.Interfaces.PasswordHasher;
using UltraNet.Framework.Modules.Auth;

namespace UltraNet.Framework.Core.Extensions;
public static class AuthServiceCollectionExtensions
{
    public static IServiceCollection AddUltraAuth(this IServiceCollection services)
    {
        services.AddScoped<ITokenGenerator, TokenGenerator>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }
}
