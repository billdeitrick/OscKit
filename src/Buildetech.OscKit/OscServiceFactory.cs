using Buildetech.OscKit.Services;

namespace Buildetech.OscKit;

/// <inheritdoc/>
public class OscServiceFactory: IOscServiceFactory
{
    
    /// <inheritdoc/>
    public IOscClientService CreateClient(string address, int port) => new OscClientService(address, port);
    
    /// <inheritdoc/>
    public IOscServerService CreateServer(int port) => new OscServerService(port);
    
}