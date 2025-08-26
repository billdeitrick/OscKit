using Buildetech.OscKit.Services;

namespace Buildetech.OscKit.Tests.Integration;


public class MonitorCallbackTests : IDisposable
{
    
    private readonly OscServerService _server = new (9000);
    private readonly OscClientService _client = new ("127.0.0.1", 9000);

    private class MonitorCallbackIntResult
    {
        public required string Address { get; set; }
        public required int Value { get; set; }

    }

    [Fact]
    public async Task TestAddMonitorCallbackAndReturnResult()
    {

        TaskCompletionSource<MonitorCallbackIntResult> tcs = new();
        
        void MonitorCallback(string address, OscMessageValues values)
        {
            tcs.TrySetResult(new MonitorCallbackIntResult()
            {
                Address = address,
                Value = values.ReadIntElement(0)
            });
        }
        
        _server.AddMonitorCallback(MonitorCallback);
        _client.Send("/test", 1);
        
        var result = await tcs.Task;
        
        Assert.Equal("/test", result.Address);
        Assert.Equal(1, result.Value);
        
    }
    
    

    public void Dispose()
    {
        _server.Dispose();
        _client.Dispose();
    }
    
}