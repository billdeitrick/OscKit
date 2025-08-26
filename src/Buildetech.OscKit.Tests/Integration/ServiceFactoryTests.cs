using Buildetech.OscKit.Services;

namespace Buildetech.OscKit.Tests.Integration;

public class ServiceFactoryTests
{
    
    [Fact]
    public async Task TestOscClientServiceFactory()
    {
        
        var serviceFactory = new OscServiceFactory();
        
        var server = new OscServerService(9301);

        var tcs = new TaskCompletionSource<int>();

        server.TryAddMethod("/clientservicextn", values =>
        {
            tcs.TrySetResult(values.ReadIntElement(0));
        });
        
        IOscClientService client = serviceFactory.CreateClient("127.0.0.1", 9301);
        client.Send("/clientservicextn", 123);
        
        var result = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));
        
        Assert.Equal(123, result);
        
    }

    [Fact]
    public async Task TestOscServerServiceFactory()
    {
        
        var serviceFactory = new OscServiceFactory();
    
        var client = new OscClientService("127.0.0.1", 9401);
    
        var tcs = new TaskCompletionSource<int>();

        var server = serviceFactory.CreateServer(9401);
    
        server.TryAddMethod("/serverservicextn", values => { tcs.TrySetResult(values.ReadIntElement(0)); });
    
        client.Send("/serverservicextn", 456);
    
        var result = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));
    
        Assert.Equal(456, result);
        
    }
    
}