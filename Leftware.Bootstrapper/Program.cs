using System.Reflection;
using Leftware.Plugins;

var builder = WebApplication.CreateBuilder(args);
var plugins = LoadPlugins();

builder.Services.AddControllers();
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

app.MapControllers();

app.Run();

ICollection<IPlugin> LoadPlugins()
{
    var hostLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

    if (hostLocation is null)
        throw new Exception("Host location unknown (lol)");
    
    return Directory
        .EnumerateFiles(hostLocation)
        .Where(file => file.Contains("Leftware.") && file.EndsWith(".dll"))
        .Select(LoadPlugin)
        .ToArray();
}

IPlugin LoadPlugin(string pluginPath)
{
    var pluginAssembly = Assembly.LoadFrom(pluginPath);
    var providedConfigurator = pluginAssembly
        .GetTypes()
        .SingleOrDefault(x => typeof(IPlugin).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

    if (providedConfigurator is null)
        return new EmptyPlugin();

    return Activator.CreateInstance(providedConfigurator) as IPlugin ?? new EmptyPlugin();
}