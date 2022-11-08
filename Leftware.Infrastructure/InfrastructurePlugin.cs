using Leftware.Infrastructure.InternalBus;
using Leftware.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Infrastructure;

public class InfrastructurePlugin : IPlugin
{
    public void RegisterDependencies(IServiceCollection services)
    {
        services.AddSingleton<IMessageBus, MessageBus>();
    }

    public void Enable(IApplicationBuilder app)
    {
    }
}