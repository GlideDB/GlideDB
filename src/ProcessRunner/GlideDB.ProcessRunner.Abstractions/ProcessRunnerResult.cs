namespace GlideDB.ProcessRunner.Abstractions;

public class ProcessRunnerResult
{
    public int ExitCode { get; set; }
    public string Output { get; set; }
    public string Error { get; set; }
}