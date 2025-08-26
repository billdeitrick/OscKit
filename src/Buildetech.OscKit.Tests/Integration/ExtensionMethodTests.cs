using Microsoft.Extensions.DependencyInjection;
using Buildetech.OscKit.Services;

namespace Buildetech.OscKit.Tests.Integration;

public class ExtensionMethodTests
{

    [Fact]
    public async Task TestOscClientServiceExtensionMethod()
    {
        
        var services = new ServiceCollection();
        services.AddOscClientService("127.0.0.1", 9300);
        var provider = services.BuildServiceProvider();

        var server = new OscServerService(9300);

        var tcs = new TaskCompletionSource<int>();

        server.TryAddMethod("/clientservicextn", values =>
        {
            tcs.TrySetResult(values.ReadIntElement(0));
        });
        
        IOscClientService client = provider.GetRequiredService<IOscClientService>();
        client.Send("/clientservicextn", 123);
        
        var result = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));
        
        Assert.Equal(123, result);
        
    }

    [Fact]
    public async Task TestOscServerServiceExtensionMethod()
    {
        
        var services = new ServiceCollection();
        services.AddOscServerService(9400);
        var provider = services.BuildServiceProvider();

        var client = new OscClientService("127.0.0.1", 9400);

        var tcs = new TaskCompletionSource<int>();

        var server = provider.GetRequiredService<IOscServerService>();

        server.TryAddMethod("/serverservicextn", values => { tcs.TrySetResult(values.ReadIntElement(0)); });

        client.Send("/serverservicextn", 456);

        var result = await tcs.Task.WaitAsync(TimeSpan.FromSeconds(5));

        Assert.Equal(456, result);
        
    }

}