using Leftware.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Plugin.Sample;

public class SamplePlugin : IPlugin
{
    public void RegisterDependencies(IServiceCollection services)
    {
        services.AddSingleton<ISampleRegistration, SampleRegistration>();
    }

    public void Use(IApplicationBuilder app)
    {
    }
}