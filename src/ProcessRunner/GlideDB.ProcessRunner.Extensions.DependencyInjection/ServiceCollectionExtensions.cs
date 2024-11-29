using GlideDB.ProcessRunner.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace GlideDB.ProcessRunner.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProcessRunner(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IProcessRunnerExecutor, ProcessRunnerExecutor>();
        
        return serviceCollection;
    }
}
