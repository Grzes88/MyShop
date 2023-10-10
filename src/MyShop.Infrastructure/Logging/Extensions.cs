using Microsoft.Extensions.DependencyInjection;
using MyShop.Application.Abstractions;
using MyShop.Infrastructure.Logging.Decorators;


namespace MyShop.Infrastructure.Logging;

internal static class Extensions
{
    public static IServiceCollection AddCustomLogging(this IServiceCollection services)
    {
        services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

        return services;
    }
}
