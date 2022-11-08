using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Plugins;

public sealed class EmptyPlugin : IPlugin
{
    public void RegisterDependencies(IServiceCollection services)
    {
    }

    public void Enable(IApplicationBuilder app)
    {
    }
}

public interface IPlugin
{
    void RegisterDependencies(IServiceCollection services);
    void Enable(IApplicationBuilder app);
}

public static class FancyExtensions
{
    public static IServiceCollection AddPlugins(this IServiceCollection services, IEnumerable<IPlugin> plugins)
    {
        foreach (var plugin in plugins)
            plugin.RegisterDependencies(services);

        return services;
    }
    
    public static IApplicationBuilder UsePlugins(this IApplicationBuilder app, IEnumerable<IPlugin> plugins)
    {
        foreach (var plugin in plugins)
            plugin.Enable(app);

        return app;
    }
}