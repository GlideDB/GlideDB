namespace GlideDB.ProcessRunner.Abstractions;

public interface IProcessRunnerExecutor
{
    ProcessRunnerResult Execute(string fileName, string workingDirectory, bool outputToConsole, params string[] arguments);
}
