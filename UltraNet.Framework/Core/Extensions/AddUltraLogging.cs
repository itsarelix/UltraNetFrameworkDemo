using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using UltraNet.Framework.Core.Interfaces.Logging;
using UltraNet.Modules.Logging;
using UltraNet.Framework.Modules.Logging.Decorators;


namespace UltraNet.Framework.Core.Extensions;
public static class LoggingServiceCollectionExtensions
{
    public static IServiceCollection AddUltraLogging(this IServiceCollection services)
    {
        services.TryAddEnumerable(ServiceDescriptor.Scoped<ILoggerService, ConsoleLogger>());
        services.TryAddEnumerable(ServiceDescriptor.Scoped<ILoggerService, SerilogLogger>());
        services.AddScoped<ICompositeLogger,CompositeLogger>();

        return services;
    }
}

