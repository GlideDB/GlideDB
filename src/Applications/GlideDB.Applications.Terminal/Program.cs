using System.Reflection;
using GlideDB.Applications.Terminal.Commands;
using GlideDB.Host;
using GlideDB.Host.Extensions;
using McMaster.Extensions.CommandLineUtils;

namespace GlideDB.Applications.Terminal;

class Program
{
    static int Main(string[] args)
    {
        var glideDbHost = new GlideDbHost()
            .AddSingleton(PhysicalConsole.Singleton)
            .Build();
        
        var app = new CommandLineApplication<RootCommand>
        {
            UnrecognizedArgumentHandling = UnrecognizedArgumentHandling.StopParsingAndCollect
        };

        app.Conventions
            .UseDefaultConventions()
            .UseConstructorInjection(glideDbHost.GetServiceProvider());

        WriteHeader();
        
        var exitCode = app.Execute(args);
        
        return exitCode;
    }
    
    
    private static void WriteHeader()
    {
        var possibleBuildDate = new FileInfo(Assembly.GetExecutingAssembly().Location).LastWriteTime;
        var version = typeof(Program).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()!.InformationalVersion;

        Console.WriteLine($"(c) GlideDB 2024 - {DateTime.Now.Year}");
        Console.WriteLine($"  Version:     {version,-20}");
        Console.WriteLine($"  Built:       {possibleBuildDate:yyyy-MM-dd HH:mm:ss}");
        Console.WriteLine($"  Started:     {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        
        Console.WriteLine();
    }
}
