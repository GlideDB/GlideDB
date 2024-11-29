using McMaster.Extensions.CommandLineUtils;

namespace GlideDB.Applications.Terminal.Commands;

[Command("GlideDB")]
public class RootCommand
{
    private int OnExecute(CommandLineApplication app)
    {
        app.ShowHelp();
            
        return 0;
    }
}