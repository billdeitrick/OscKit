using Microsoft.Extensions.DependencyInjection;
using Buildetech.OscKit.Services;

namespace Buildetech.OscKit;

/// <summary>
/// Extension methods for registering OSC Kit services in an IServiceCollection.
/// </summary>
public static class OscKitExtensionMethods
{
    
    /// <summary>
    /// Add a singleton instance of IOscClientService to the DI container.
    /// </summary>
    /// <param name="services">The IServiceCollection object.</param>
    /// <param name="ipAddress">The IP Address of the OSC Server with which this client will communicate.</param>
    /// <param name="port">The port over which this client will transmit OSC messages.</param>
    public static void AddOscClientService(this IServiceCollection services, string ipAddress, int port)
    {
        services.AddSingleton<IOscClientService>(provider => new OscClientService(ipAddress, port));
    }
    
    /// <summary>
    /// Add a singleton instance of IOscServerService to the DI container.
    /// </summary>
    /// <param name="services">The IServiceCollection object.</param>
    /// <param name="port">The port on which the server should listen for OSC messges.</param>
    public static void AddOscServerService(this IServiceCollection services, int port)
    {
        services.AddSingleton<IOscServerService>(provider => new OscServerService(port));
    }
    
}