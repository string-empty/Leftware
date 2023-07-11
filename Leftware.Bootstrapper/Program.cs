using FastEndpoints;
using FastEndpoints.Swagger;
using Leftware.Bootstrapper;
using Leftware.Infrastructure;
using Leftware.Plugins;

var builder = WebApplication.CreateBuilder(args);
var plugins = PluginLibraryLoader.LoadPlugins();

var serviceCollection = builder
    .AddPluginConfiguration()
    .Services;

serviceCollection
    .AddFastEndpoints(o => o.ScanFastEndpoints())
    .SwaggerDocument()
    .AddHealthChecks()
    .AddPluginHealthChecks(plugins);

serviceCollection
    .AddInternalBus()
    .AddPlugins(plugins)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers()
    .AddPluginControllers();

var app = builder.Build();
app.MapHealthChecks("/alive");

app
    .UsePlugins(plugins)
    .UseRouting()
    .UseFastEndpoints()
    .UseEndpoints(a => a.MapControllers())
    .UseSwaggerGen()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseAuthorization();

app.Run();