using Leftware.Plugins;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Leftware.Plugin.Sample;

public class SamplePlugin : IPlugin
{
    public void RegisterDependencies(IServiceCollection services)
    {
    }

    public void Use(IApplicationBuilder app)
    {
    }
}