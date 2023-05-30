using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Plugins;

public interface IPlugin
{
    void RegisterDependencies(IServiceCollection services);
    void Use(IApplicationBuilder app);
    void AddHealthCheck(IHealthChecksBuilder healthChecksBuilder);
}