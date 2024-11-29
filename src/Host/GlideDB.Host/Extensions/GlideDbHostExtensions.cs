namespace GlideDB.Host.Extensions;

public static class GlideDbHostExtensions
{
    
    public static GlideDbHost AddSingleton<TService>(
        this GlideDbHost glideDbHost,
        TService implementationInstance)
        where TService : class
    {
        glideDbHost.RegisterSingleton(implementationInstance);
        
        return glideDbHost;
    }
    
    public static GlideDbHost Build(this GlideDbHost glideDbHost)
    {
        glideDbHost.BuildServiceProvider();
        
        return glideDbHost;
    }
    
}