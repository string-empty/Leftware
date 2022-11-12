using Leftware.Bootstrapper;
using Leftware.Infrastructure;
using Leftware.Plugins;

var builder = WebApplication.CreateBuilder(args);
var plugins = PluginLibraryLoader.LoadPlugins();

builder
    .AddPluginConfiguration()
    .Services
    .AddInternalBus()
    .AddPlugins(plugins)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers()
    .AddPluginControllers();

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