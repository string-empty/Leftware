using Leftware.Bootstrapper;
using Leftware.Infrastructure;
using Leftware.Plugins;

var builder = WebApplication.CreateBuilder(args);
var plugins = PluginLibraryLoader.LoadPlugins();

builder.Services
    .AddInternalBus()
    .AddPlugins(plugins)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers()
    .AddPluginControllers(plugins);

var app = builder.Build();

app
    .UsePlugins(plugins)
    .UseRouting()
    .UseEndpoints(a => a.MapControllers())
    .UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseAuthorization();

app.Run();