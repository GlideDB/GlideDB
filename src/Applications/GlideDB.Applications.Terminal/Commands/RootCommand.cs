using GlideDB.ProcessRunner.Abstractions;
using McMaster.Extensions.CommandLineUtils;

namespace GlideDB.Applications.Terminal.Commands;

[Command("GlideDB")]
public class RootCommand(IProcessRunnerExecutor a)
{
    private int OnExecute(CommandLineApplication app)
    {
        var b = a.Execute("dotnet", "c:\\", true);
        
        Console.WriteLine("dcewcedwdcewcewcewcw");
        
        Console.WriteLine(b.Output.ToString());
        app.ShowHelp();
            
        return 0;
    }
}