using System.Reflection;
using FastEndpoints;
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
    
    public static void ScanFastEndpoints(this EndpointDiscoveryOptions options)
    {
        options.Assemblies = GetAssembliesWithControllers();
        options.DisableAutoDiscovery = true;
    }
    
    public static IMvcBuilder AddPluginControllers(
        this IMvcBuilder mvcBuilder)
    {
        foreach (var assembly in GetAssembliesWithControllers())
            mvcBuilder.AddApplicationPart(assembly);

        return mvcBuilder;
    }
    
    public static IHealthChecksBuilder AddPluginHealthChecks(
        this IHealthChecksBuilder healthChecksBuilder, IEnumerable<IPlugin> plugins)
    {
        foreach (var plugin in plugins)
            plugin.AddHealthCheck(healthChecksBuilder);

        return healthChecksBuilder;
    }
    
    private static ICollection<Assembly> GetAssembliesWithControllers()
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        var hostLocation = Path.GetDirectoryName(executingAssembly.Location);

        if (hostLocation is null)
            throw new Exception("Host location unknown (lol)");

        return Directory
            .EnumerateFiles(hostLocation)
            .Where(file => Path.GetFileName(file).EndsWith(".Api.dll"))
            .Select(Assembly.LoadFrom)
            .ToArray();
    }
}