using Leftware.Infrastructure.InternalBus;
using Leftware.Plugin.Sample.Configuration;
using Leftware.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Plugin.Sample;

public class SamplePlugin : IPlugin
{
    public void RegisterDependencies(IServiceCollection services)
    {
        services.AddSingleton<ICommandHandler<SampleRequest>, SampleRequestHandler>();
        services.AddPluginOptions<SampleSection>();
    }

    public void Use(IApplicationBuilder app)
    {
    }

    public void AddHealthCheck(IHealthChecksBuilder healthChecksBuilder)
    {
        healthChecksBuilder.AddCheck<SampleHealtCheck>("Sample");
    }
}