using System.Diagnostics;
using System.Text;
using GlideDB.ProcessRunner.Abstractions;

namespace GlideDB.ProcessRunner;

public class ProcessRunnerExecutor : IProcessRunnerExecutor
{
    public ProcessRunnerResult Execute(string fileName, string workingDirectory, bool outputToConsole, params string[] arguments)
    {
        var processStartInfo = new ProcessStartInfo(fileName, string.Join(" ", arguments))
        {
            UseShellExecute = false,
            CreateNoWindow = true,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            WorkingDirectory = workingDirectory
        };

        var stdOut = new StringBuilder();
        var stdErr = new StringBuilder();

        int exitCode;

        using (var proc = new Process())
        {
            proc.StartInfo = processStartInfo;
            proc.Start();

            using (var reader = proc.StandardOutput)
            {
                while (!reader.EndOfStream)
                {
                    var lineContent = reader.ReadLine();
                    stdOut.AppendLine(lineContent);
                    Console.WriteLine(lineContent);
                }
            }
            
            using (var reader = proc.StandardError)
            {
                while (!reader.EndOfStream)
                {
                    var lineContent = reader.ReadLine();
                    stdErr.AppendLine(lineContent);
                    Console.WriteLine(lineContent);
                }
            }
            
            proc.StandardError.Close();
            proc.StandardOutput.Close();

            exitCode = proc.ExitCode;

            proc.Close();
                
        }

        return new ProcessRunnerResult
        {
            ExitCode = exitCode,
            Output = stdOut.ToString(),
            Error = stdErr.ToString()
        };
    }
}
