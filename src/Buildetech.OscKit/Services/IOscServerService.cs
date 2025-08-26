using System;

namespace Buildetech.OscKit.Services;

/// <summary>
/// Represents a service for receiving and handling OSC (Open Sound Control) messages received from remote hosts.
/// </summary>
public interface IOscServerService
{
    /// <summary>
    /// Adds a method callback for the specified OSC address.
    /// </summary>
    /// <param name="address">The OSC address to monitor.</param>
    /// <param name="action">The callback to invoke when a message is received at the address.</param>
    /// <returns>True if the method was added; otherwise, false.</returns>
    bool TryAddMethod(string address, Action<OscMessageValues> action);

    /// <summary>
    /// Removes a method callback for the specified OSC address.
    /// </summary>
    /// <param name="address">The OSC address to remove the callback from.</param>
    /// <param name="action">The callback to remove.</param>
    /// <returns>True if the method was removed; otherwise, false.</returns>
    bool RemoveMethod(string address, Action<OscMessageValues> action);

    /// <summary>
    /// Removes all method callbacks for the specified OSC address.
    /// </summary>
    /// <param name="address">The OSC address to remove.</param>
    /// <returns>True if the address was removed; otherwise, false.</returns>
    bool RemoveAddress(string address);

    /// <summary>
    /// Adds a monitor callback that is invoked for every OSC message received.
    /// </summary>
    /// <param name="callback">The monitor callback to add.</param>
    void AddMonitorCallback(MonitorCallback callback);

    /// <summary>
    /// Removes a monitor callback.
    /// </summary>
    /// <param name="callback">The monitor callback to remove.</param>
    /// <returns>True if the callback was removed; otherwise, false.</returns>
    bool RemoveMonitorCallback(MonitorCallback callback);

    /// <summary>
    /// Releases all resources used by the <see cref="OscServerService"/>.
    /// </summary>
    void Dispose();
}