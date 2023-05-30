using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Plugins;

public sealed class EmptyPlugin : IPlugin
{
    public void RegisterDependencies(IServiceCollection services)
    {
    }

    public void Use(IApplicationBuilder app)
    {
    }

    public void AddHealthCheck(IHealthChecksBuilder healthChecksBuilder)
    {
    }
}