using Leftware.Bootstrapper;
using Leftware.Plugins;

var builder = WebApplication.CreateBuilder(args);
var plugins = PluginLibraryLoader.LoadPlugins();

builder.Services
    .AddPlugins(plugins)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

var app = builder.Build();

app
    .UsePlugins(plugins)
    .UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseAuthorization();

app.Run();