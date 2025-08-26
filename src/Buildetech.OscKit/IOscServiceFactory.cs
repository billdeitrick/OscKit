using Buildetech.OscKit.Services;

namespace Buildetech.OscKit;

/// <summary>
/// Provides methods to create OSC client and server services.
/// </summary>
public interface IOscServiceFactory {
    
    /// <summary>
    /// Create an OSC client service.
    /// </summary>
    /// <param name="address">The remote address to which OSC messages should be sent.</param>
    /// <param name="port">The port that should be used at the remote address.</param>
    /// <returns></returns>
    IOscClientService CreateClient(string address, int port);
    
    /// <summary>
    /// Create an OSC server service.
    /// </summary>
    /// <param name="port">The port on which we should listen for incoming OSC messages.</param>
    /// <returns></returns>
    IOscServerService CreateServer(int port);
    
}

