using System.Reflection;
using Leftware.Plugins;

namespace Leftware.Bootstrapper;

public static class PluginLibraryLoader
{
    public static ICollection<IPlugin> LoadPlugins()
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

    private static IPlugin LoadPlugin(string pluginPath)
    {
        var pluginAssembly = Assembly.LoadFrom(pluginPath);
        var providedConfigurator = pluginAssembly
            .GetTypes()
            .SingleOrDefault(x => typeof(IPlugin).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract);

        if (providedConfigurator is null)
            return new EmptyPlugin();

        return Activator.CreateInstance(providedConfigurator) as IPlugin ?? new EmptyPlugin();
    }
}