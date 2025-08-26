using System;
using Buildetech.OscKit.Types;

namespace Buildetech.OscKit.Services;

/// <summary>
/// Represents a service for sending OSC (Open Sound Control) messages to a remote host.
/// </summary>
public interface IOscClientService
{
    /// <summary>
    /// Sends an OSC message to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    void Send(string address);

    /// <summary>
    /// Sends an OSC message with an integer element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The integer element to include in the message.</param>
    void Send(string address, int element);

    /// <summary>
    /// Sends an OSC message with an OscInt element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscInt element to include in the message.</param>
    void Send(string address, OscInt element);

    /// <summary>
    /// Sends an OSC message with a float element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The float element to include in the message.</param>
    void Send(string address, float element);

    /// <summary>
    /// Sends an OSC message with an OscFloat element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscFloat element to include in the message.</param>
    void Send(string address, OscFloat element);

    /// <summary>
    /// Sends an OSC message with a string element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The string element to include in the message.</param>
    void Send(string address, string element);

    /// <summary>
    /// Sends an OSC message with an OscString element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscString element to include in the message.</param>
    void Send(string address, OscString element);

    /// <summary>
    /// Sends an OSC message with a byte array to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="bytes">The byte array to include in the message.</param>
    /// <param name="length">The number of bytes to send.</param>
    /// <param name="start">The starting index in the byte array.</param>
    void Send(string address, byte[] bytes, int length, int start = 0);

    /// <summary>
    /// Sends an OSC message with a byte array to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscByteArray element to include in the message. The entire array will be sent.</param>
    void Send(string address, OscByteArray element);

    /// <summary>
    /// Sends an OSC message with a double element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The double element to include in the message.</param>
    void Send(string address, double element);

    /// <summary>
    /// Sends an OSC message with an OscDouble element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscDouble element to include in the message.</param>
    void Send(string address, OscDouble element);

    /// <summary>
    /// Sends an OSC message with a long element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The long element to include in the message.</param>
    void Send(string address, long element);

    /// <summary>
    /// Sends an OSC message with an OscLong element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscLong element to include in the message.</param>
    void Send(string address, OscLong element);

    /// <summary>
    /// Sends an OSC message with a OscColor32 element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscColor32 element to include in the message.</param>
    void Send(string address, OscColor32 element);

    /// <summary>
    /// Sends an OSC message with a OscMidiMessage element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscMidiMessage element to include in the message.</param>
    void Send(string address, OscMidiMessage element);

    /// <summary>
    /// Sends an OSC message with a char element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The char element to include in the message.</param>
    void Send(string address, char element);

    /// <summary>
    /// Sends an OSC message with an OscChar element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscChar element to include in the message.</param>
    void Send(string address, OscChar element);

    /// <summary>
    /// Sends an OSC message with a boolean element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The boolean element to include in the message.</param>
    void Send(string address, bool element);

    /// <summary>
    /// Sends an OSC message with an OscTrue element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscTrue element to include in the message.</param>
    void Send(string address, OscTrue element);

    /// <summary>
    /// Sends an OSC message with an OscFalse element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscFalse element to include in the message.</param>
    void Send(string address, OscFalse element);

    /// <summary>
    /// Sends an OSC message with an OscNil value to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscNil element to include in the message.</param>
    void Send(string address, OscNil element);

    /// <summary>
    /// Sends an OSC message with an OscInfinitum value to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscInfinitum element to include in the message.</param>
    void Send(string address, OscInfinitum element);

    /// <summary>
    /// Sends an OSC message with a element to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The element to include in the message.</param>
    void Send(string address, DateTime element);

    /// <summary>
    /// Sends an OSC message with an OscTimestamp to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="element">The OscTimestamp element to include in the message.</param>
    void Send(string address, OscTimestamp element);

    /// <summary>
    /// Sends a custom OSC message with multiple elements to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    /// <param name="elements">The array of elements to be sent.</param>
    void Send(string address, IOscWriteable[] elements);

    /// <summary>
    /// Sends an OSC message with a nil value to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    void SendNil(string address);

    /// <summary>
    /// Sends an OSC message with an infinitum value to the specified address.
    /// </summary>
    /// <param name="address">The OSC address to send the message to.</param>
    void SendInfinitum(string address);

    /// <summary>
    /// Releases all resources used by the <see cref="OscClientService"/>.
    /// </summary>
    void Dispose();
}