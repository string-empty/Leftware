using Leftware.Bootstrapper;
using Leftware.Infrastructure;
using Leftware.Plugins;

var builder = WebApplication.CreateBuilder(args);
var plugins = PluginLibraryLoader.LoadPlugins();

var serviceCollection = builder
    .AddPluginConfiguration()
    .Services;

serviceCollection.AddHealthChecks().AddPluginHealthChecks(plugins);

serviceCollection
    .AddInternalBus()
    .AddPlugins(plugins)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers()
    .AddPluginControllers();

var app = builder.Build();
app.MapHealthChecks("/healthz");

app
    .UsePlugins(plugins)
    .UseRouting()
    .UseEndpoints(a => a.MapControllers())
    .UseSwagger()
    .UseSwaggerUI()
    .UseHttpsRedirection()
    .UseAuthorization();

app.Run();