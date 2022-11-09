using System.Reflection;
using Leftware.Plugins;

namespace Leftware.Bootstrapper;

public static class PluginLibraryLoader
{
    public static ICollection<IPlugin> LoadPlugins()
    {
        var executingAssembly = Assembly.GetExecutingAssembly();
        var hostLocation = Path.GetDirectoryName(executingAssembly.Location);

        if (hostLocation is null)
            throw new Exception("Host location unknown (lol)");
    
        return Directory
            .EnumerateFiles(hostLocation)
            .Except(new[] { executingAssembly.Location })
            .Where(file =>
            {
                var fileName = Path.GetFileName(file);
                return fileName.StartsWith("Leftware.Plugin.") && Path.GetExtension(fileName) == ".dll";
            })
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