using System;
using System.Linq;
using System.Net.Sockets;
using Buildetech.OscCore;
using Buildetech.OscKit.Types;
using MiniNtp;

namespace Buildetech.OscKit.Services;

/// <summary>
/// Service for sending OSC (Open Sound Control) messages to a remote host.
/// </summary>
internal class OscClientService : IOscClientService
{

    private OscClient _client;
    
    /// <summary>
    /// Initializes a new instance of the <see cref="OscClientService"/> class with the specified IP address and port.
    /// </summary>
    /// <param name="ipAddress">The IP address of the OSC server.</param>
    /// <param name="port">The port number of the OSC server.</param>
    public OscClientService(string ipAddress, int port)
    {

        _client = new OscClient(ipAddress, port);

    }

    /// <inheritdoc/>
    public void Send(string address)
    {
        _client.Send(address);
    }
    
    /// <inheritdoc/>
    public void Send(string address, int element)
    {
        _client.Send(address, element);
    }

    /// <inheritdoc/>
    public void Send(string address, OscInt element)
    {
        _client.Send(address, element.Value);
    }

    /// <inheritdoc/>
    public void Send(string address, float element)
    {
        _client.Send(address, element);
    }
    
    /// <inheritdoc/>
    public void Send(string address, OscFloat element)
    {
        _client.Send(address, element.Value);
    }

    /// <inheritdoc/>
    public void Send(string address, string element)
    {
        _client.Send(address, element);
    }

    /// <inheritdoc/>
    public void Send(string address, OscString element)
    {
        _client.Send(address, element.Value);
    }

    /// <inheritdoc/>
    public void Send(string address, byte[] bytes, int length, int start = 0)
    {
        _client.Send(address, bytes, length, start);
    }

    /// <inheritdoc/>
    public void Send(string address, OscByteArray element)
    {
        _client.Send(address, element.Bytes, element.Bytes.Length, 0);
    }

    /// <inheritdoc/>
    public void Send(string address, double element)
    {
        _client.Send(address, element);
    }
    
    /// <inheritdoc/>
    public void Send(string address, OscDouble element)
    {
        _client.Send(address, element.Value);
    }

    /// <inheritdoc/>
    public void Send(string address, long element)
    {
        _client.Send(address, element);
    }
    
    /// <inheritdoc/>
    public void Send(string address, OscLong element)
    {
        _client.Send(address, element.Value);
    }

    /// <inheritdoc/>
    public void Send(string address, OscColor32 element)
    {
        _client.Send(address, element.GetColor32());
    }

    /// <inheritdoc/>
    public void Send(string address, OscMidiMessage element)
    {
        _client.Send(address, element.GetMidiMessage());
    }

    /// <inheritdoc/>
    public void Send(string address, char element)
    {
        _client.Send(address, element);
    }
    
    /// <inheritdoc/>
    public void Send(string address, OscChar element)
    {
        _client.Send(address, element.Value);
    }

    /// <inheritdoc/>
    public void Send(string address, bool element)
    {
        _client.Send(address, element);
    }

    /// <inheritdoc/>
    public void Send(string address, OscTrue element)
    {
        _client.Send(address, true);
    }
    
    /// <inheritdoc/>
    public void Send(string address, OscFalse element)
    {
        _client.Send(address, false);
    }

    /// <inheritdoc/>
    public void SendNil(string address)
    {
        _client.SendNil(address);
    }
    
    /// <inheritdoc/>
    public void Send(string address, OscNil element)
    {
        _client.SendNil(address);
    }

    /// <inheritdoc/>
    public void SendInfinitum(string address)
    {
        _client.SendInfinitum(address);
    }
    
    /// <inheritdoc/>
    public void Send(string address, OscInfinitum element)
    {
        _client.SendInfinitum(address);
    }

    /// <inheritdoc/>
    public void Send(string address, DateTime element)
    {
        var ts = new NtpTimestamp(element);
        _client.Writer.Reset();
        _client.Writer.Write(address);
        _client.Writer.Write(",t");
        _client.Writer.Write(ts);
        _client.Socket.Send(_client.Writer.Buffer, _client.Writer.Length, SocketFlags.None);
    }

    /// <inheritdoc/>
    public void Send(string address, OscTimestamp element)
    {
        Send(address, element.Value);
    }
    
    /// <inheritdoc/>
    public void Send(string address, IOscWriteable[] elements)
    {
        
        _client.Writer.Reset();
        _client.Writer.Write(address);
        _client.Writer.Write("," + string.Join("", elements.Select(e => ((char)e.GetOscTypeTag()).ToString())));
        
        foreach (var element in elements)
        {
            element.WriteTo(_client.Writer);
        }
        
        _client.Socket.Send(_client.Writer.Buffer, _client.Writer.Length, SocketFlags.None);
        
    }

    /// <summary>
    /// Releases all resources used by the <see cref="OscClientService"/>.
    /// </summary>
    public void Dispose()
    {
        _client.Dispose();
    }

    ~OscClientService()
    {
        _client.Dispose();
    }
    
}