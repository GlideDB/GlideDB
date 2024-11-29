using Microsoft.Extensions.DependencyInjection;

namespace GlideDB.Host;

public class GlideDbHost
{
    private readonly IServiceCollection _serviceCollection = new ServiceCollection();
    private IServiceProvider? _serviceProvider;

    public void RegisterSingleton<TService>(TService implementationInstance)
        where TService : class
    {
        if (AllowRegistration)
        {
            _serviceCollection.AddSingleton(typeof(TService), implementationInstance);
        }
        else
        {
            throw new InvalidOperationException($"Cannot register service of type {typeof(TService).Name}");
        }
    }

    public void BuildServiceProvider()
    {
        _serviceProvider = _serviceCollection.BuildServiceProvider();
    }
    
    private bool AllowRegistration => _serviceProvider == null;

    public IServiceProvider GetServiceProvider()
    {
        if (AllowRegistration)
        {
            throw new Exception();
        }

        if (_serviceProvider == null)
        {
            throw new Exception();
        }

        return _serviceProvider;
    }
}
