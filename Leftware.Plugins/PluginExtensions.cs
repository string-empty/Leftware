using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Plugins;

public static class PluginExtensions
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
            plugin.Use(app);

        return app;
    }
    
    public static IMvcBuilder AddPluginControllers(
        this IMvcBuilder mvcBuilder,
        IEnumerable<IPlugin> plugins)
    {
        foreach (var plugin in plugins)
            mvcBuilder.AddApplicationPart(plugin.GetType().Assembly);

        return mvcBuilder;
    }
}