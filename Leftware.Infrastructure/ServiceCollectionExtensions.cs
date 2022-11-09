using Leftware.Infrastructure.InternalBus;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInternalBus(this IServiceCollection services)
    {
        services.AddSingleton<IMessageBus, MessageBus>();
        return services;
    }
}