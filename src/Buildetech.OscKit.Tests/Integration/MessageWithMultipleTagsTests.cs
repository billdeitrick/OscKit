using Buildetech.OscKit.Services;
using System.Collections;
using Buildetech.OscKit.Types;

namespace Buildetech.OscKit.Tests.Integration;

public class MessageWithMultipleTagsTests : IDisposable
{
    private readonly OscServerService _server = new(9101);
    private readonly OscClientService _client = new("127.0.0.1", 9101);

    private Task<OscMessageValues> MonitorAsync(string address)
    {
        var tcs = new TaskCompletionSource<OscMessageValues>();
        void Callback(string cbAddress, OscMessageValues values)
        {
            if (cbAddress == address)
            {
                tcs.TrySetResult(values);
            }
        }
        _server.AddMonitorCallback(Callback);
        return tcs.Task;
    }

    public static IEnumerable<object[]> MultipleTagTestData()
    {
        yield return new object[] { "/multi/int_float", new IOscWriteable[] { new OscInt(42), new OscFloat(3.14f) }, new Func<OscMessageValues, bool>(v => v.ReadIntElement(0) == 42 && Math.Abs(v.ReadReadFloatElement(1) - 3.14f) < 0.001) };
        yield return new object[] { "/multi/string_bool", new IOscWriteable[] { new OscString("hello"), new OscTrue() }, new Func<OscMessageValues, bool>(v => v.ReadStringElement(0) == "hello" && v.ReadBoolElement(1)) };
        yield return new object[] { "/multi/long_double", new IOscWriteable[] { new OscLong(1234567890123L), new OscDouble(2.718) }, new Func<OscMessageValues, bool>(v => v.ReadInt64Element(0) == 1234567890123L && Math.Abs(v.ReadFloat64Element(1) - 2.718) < 0.001) };
        yield return new object[] { "/multi/char_bytes", new IOscWriteable[] { new OscChar('A'), new OscByteArray(new byte[] { 1, 2, 3 }) }, new Func<OscMessageValues, bool>(v => v.ReadAsciiCharElement(0) == 'A' && StructuralComparisons.StructuralEqualityComparer.Equals(v.ReadBlobElement(1), new byte[] { 1, 2, 3 })) };
        yield return new object[] { "/multi/color_midi", new IOscWriteable[] { new OscColor32(10, 20, 30, 40), new OscMidiMessage(0x90, 0x40, 0x7F, 0x00) }, new Func<OscMessageValues, bool>(v => v.ReadColor32Element(0).Equals(new OscColor32(10, 20, 30, 40)) && v.ReadMidiElement(1).Equals(new OscMidiMessage(0x90, 0x40, 0x7F, 0x00))) };
        yield return new object[] { "/multi/int_float_string", new IOscWriteable[] { new OscInt(7), new OscFloat(1.23f), new OscString("abc") }, new Func<OscMessageValues, bool>(v => v.ReadIntElement(0) == 7 && Math.Abs(v.ReadReadFloatElement(1) - 1.23f) < 0.001 && v.ReadStringElement(2) == "abc") };
        yield return new object[] { "/multi/long_double_bool", new IOscWriteable[] { new OscLong(99L), new OscDouble(0.5), new OscTrue() }, new Func<OscMessageValues, bool>(v => v.ReadInt64Element(0) == 99L && Math.Abs(v.ReadFloat64Element(1) - 0.5) < 0.001 && v.ReadBoolElement(2)) };
        yield return new object[] { "/multi/char_bytes_string", new IOscWriteable[] { new OscChar('Z'), new OscByteArray(new byte[] { 9, 8, 7 }), new OscString("xyz") }, new Func<OscMessageValues, bool>(v => v.ReadAsciiCharElement(0) == 'Z' && StructuralComparisons.StructuralEqualityComparer.Equals(v.ReadBlobElement(1), new byte[] { 9, 8, 7 }) && v.ReadStringElement(2) == "xyz") };
    }

    [Theory]
    [MemberData(nameof(MultipleTagTestData))]
    public async Task SendReceive_MultipleTags(string address, IOscWriteable[] elements, Func<OscMessageValues, bool> validator)
    {
        var task = MonitorAsync(address);
        _client.Send(address, elements);
        var values = await task;
        Assert.True(validator(values));
    }

    public void Dispose()
    {
        _server.Dispose();
        _client.Dispose();
    }
}