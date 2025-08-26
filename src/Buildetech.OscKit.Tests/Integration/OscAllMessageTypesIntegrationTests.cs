using Buildetech.OscKit.Services;
using Buildetech.OscKit.Types;

namespace Buildetech.OscKit.Tests.Integration
{
    public class OscAllMessageTypesIntegrationTests : System.IDisposable
    {
        private readonly OscServerService _server = new(9100);
        private readonly OscClientService _client = new("127.0.0.1", 9100);

        private Task<T> MonitorAsync<T>(string address, Func<OscMessageValues, T> valueSelector)
        {
            var tcs = new TaskCompletionSource<T>();
            void Callback(string cbAddress, OscMessageValues values)
            {
                if (cbAddress == address)
                {
                    tcs.TrySetResult(valueSelector(values));
                }
            }
            _server.AddMonitorCallback(Callback);
            return tcs.Task;
        }
        
        [Fact]
        public async Task SendReceive_StringOnly()
        {
            var task = MonitorAsync("/string", v => true);
            _client.Send("/string", string.Empty);
            Assert.True(await task);
        }

        [Fact]
        public async Task SendReceive_Int()
        {
            var task = MonitorAsync("/int", v => v.ReadIntElement(0));
            _client.Send("/int", 42);
            Assert.Equal(42, await task);
        }

        [Fact]
        public async Task SendReceive_Float()
        {
            var task = MonitorAsync("/float", v => v.ReadReadFloatElement(0));
            _client.Send("/float", 3.14f);
            Assert.Equal(3.14f, await task, 3);
        }

        [Fact]
        public async Task SendReceive_String()
        {
            var task = MonitorAsync("/string", v => v.ReadStringElement(0));
            _client.Send("/string", "hello");
            Assert.Equal("hello", await task);
        }

        [Fact]
        public async Task SendReceive_ByteArray()
        {
            var bytes = new byte[] { 1, 2, 3, 4 };
            var task = MonitorAsync("/bytes", v => v.ReadBlobElement(0));
            _client.Send("/bytes", bytes, bytes.Length);
            Assert.Equal(bytes, await task);
        }

        [Fact]
        public async Task SendReceive_Double()
        {
            var task = MonitorAsync("/double", v => v.ReadFloat64Element(0));
            _client.Send("/double", 2.718);
            Assert.Equal(2.718, await task, 3);
        }

        [Fact]
        public async Task SendReceive_Long()
        {
            var task = MonitorAsync("/long", v => v.ReadInt64Element(0));
            _client.Send("/long", 1234567890123L);
            Assert.Equal(1234567890123L, await task);
        }

        [Fact]
        public async Task SendReceive_Char()
        {
            var task = MonitorAsync("/char", v => v.ReadAsciiCharElement(0));
            _client.Send("/char", 'A');
            Assert.Equal('A', await task);
        }

        [Fact]
        public async Task SendReceive_Bool()
        {
            var task = MonitorAsync("/bool", v => v.ReadBoolElement(0));
            _client.Send("/bool", true);
            Assert.True(await task);
        }
        
        [Fact]
        public async Task SendReceive_Nil()
        {
            var task = MonitorAsync("/nil", v => v.ReadNilOrInfinitumElement(0));
            _client.SendNil("/nil");
            Assert.True(await task);
        }

        [Fact]
        public async Task SendReceive_Infinitum()
        {
            var task = MonitorAsync("/infinitum", v => v.ReadNilOrInfinitumElement(0));
            _client.SendInfinitum("/infinitum");
            Assert.True(await task);
        }
        
        [Fact]
        public async Task SendReceive_Color32()
        {
            var color = new OscColor32(10, 20, 30, 40);
            var task = MonitorAsync("/color32", v => v.ReadColor32Element(0));
            _client.Send("/color32", color);
            Assert.Equal(color, await task);
        }

        [Fact]
        public async Task SendReceive_MidiMessage()
        {
            var midi = new OscMidiMessage(0x90, 0x40, 0x7F, 0x00);
            var task = MonitorAsync("/midi", v => v.ReadMidiElement(0));
            _client.Send("/midi", midi);
            Assert.Equal(midi, await task);
        }
        
        [Fact]
        public async Task SendReceive_OscNil()
        {
            var task = MonitorAsync("/oscnil", v => v.ReadNilOrInfinitumElement(0));
            _client.Send("/oscnil", new OscNil());
            Assert.True(await task);
        }
        
        [Fact]
        public async Task SendReceive_Timestamp()
        {
            var task = MonitorAsync("/timestamp", v => v.ReadTimestampElement(0));
            var timestamp = new DateTime(2025, 1, 2, 3, 4, 5, DateTimeKind.Unspecified);
            
            _client.Send("/timestamp", timestamp);
            Assert.Equal(timestamp, await task);
        }

        [Fact]
        public async Task SendReceive_OscInt()
        {
            var task = MonitorAsync("/oscint", v => v.ReadIntElement(0));
            _client.Send("/oscint", new OscInt(123));
            Assert.Equal(123, await task);
        }

        [Fact]
        public async Task SendReceive_OscLong()
        {
            var task = MonitorAsync("/osclong", v => v.ReadInt64Element(0));
            _client.Send("/osclong", new OscLong(1234567890123L));
            Assert.Equal(1234567890123L, await task);
        }

        [Fact]
        public async Task SendReceive_OscString()
        {
            var task = MonitorAsync("/oscstring", v => v.ReadStringElement(0));
            _client.Send("/oscstring", new OscString("hello world"));
            Assert.Equal("hello world", await task);
        }

        [Fact]
        public async Task SendReceive_OscFloat()
        {
            var task = MonitorAsync("/oscfloat", v => v.ReadReadFloatElement(0));
            _client.Send("/oscfloat", new OscFloat(3.14f));
            Assert.Equal(3.14f, await task, 3);
        }

        [Fact]
        public async Task SendReceive_OscDouble()
        {
            var task = MonitorAsync("/oscdouble", v => v.ReadFloat64Element(0));
            _client.Send("/oscdouble", new OscDouble(2.718));
            Assert.Equal(2.718, await task, 3);
        }

        [Fact]
        public async Task SendReceive_OscFalse()
        {
            var task = MonitorAsync("/oscfalse", v => v.ReadBoolElement(0));
            _client.Send("/oscfalse", new OscFalse());
            Assert.False(await task);
        }

        [Fact]
        public async Task SendReceive_OscTrue()
        {
            var task = MonitorAsync("/osctrue", v => v.ReadBoolElement(0));
            _client.Send("/osctrue", new OscTrue());
            Assert.True(await task);
        }
        
        [Fact]
        public async Task SendReceive_OscInfinitum()
        {
            var task = MonitorAsync("/oscinfinitum", v => v.ReadNilOrInfinitumElement(0));
            _client.Send("/oscinfinitum", new OscInfinitum());
            Assert.True(await task);
        }

        [Fact]
        public async Task SendReceive_OscChar()
        {
            var task = MonitorAsync("/oscchar", v => v.ReadAsciiCharElement(0));
            _client.Send("/oscchar", new OscChar('Z'));
            Assert.Equal('Z', await task);
        }

        [Fact]
        public async Task SendReceive_OscByteArray()
        {
            var bytes = new byte[] { 5, 6, 7 };
            var task = MonitorAsync("/oscbytes", v => v.ReadBlobElement(0));
            _client.Send("/oscbytes", new OscByteArray(bytes));
            Assert.Equal(bytes, await task);
        }
        
        [Fact]
        public async Task SendReceive_OscTimestamp()
        {
            var task = MonitorAsync("/osctimestamp", v => v.ReadTimestampElement(0));
            var timestamp = new DateTime(2026, 2, 3, 4, 5, 6, DateTimeKind.Unspecified);
            _client.Send("/osctimestamp", new OscTimestamp(timestamp));
            Assert.Equal(timestamp, await task);
        }

        public void Dispose()
        {
            _server.Dispose();
            _client.Dispose();
        }
    }
}
