using Leftware.Infrastructure.Events;
using Leftware.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Infrastructure;

public class InfrastructurePlugin : IPlugin
{
    public void RegisterDependencies(IServiceCollection services)
    {
        services.AddSingleton<IEventBus, EventBus>();
    }

    public void Enable(IApplicationBuilder app)
    {
    }
}