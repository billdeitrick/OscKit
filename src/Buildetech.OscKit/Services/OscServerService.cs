using System;
using System.Collections.Generic;
using Buildetech.OscCore;

namespace Buildetech.OscKit.Services
{

    /// <summary>
    /// Service class for managing an OSC server, allowing the addition and removal of method and monitor callbacks for OSC messages.
    /// </summary>
    internal class OscServerService : IOscServerService
    {
        private readonly OscServer _server;

        private readonly Dictionary<string, Dictionary<Action<OscMessageValues>, Action<OscCore.OscMessageValues>>>
            _callbacks = new();

        private readonly Dictionary<MonitorCallback, OscCore.MonitorCallback> _monitorCallbacks = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="OscServerService"/> class and starts listening on the specified port.
        /// </summary>
        /// <param name="port">The port to listen for OSC messages.</param>
        public OscServerService(int port)
        {
            _server = OscServer.GetOrCreate(port);
        }
        
        /// <inheritdoc/>
        public bool TryAddMethod(string address, Action<OscMessageValues> action)
        {
            var dlgt = new Action<OscCore.OscMessageValues>(values => action(new OscMessageValues(values)));

            if (!_callbacks.ContainsKey(address))
            {
                _callbacks[address] = new Dictionary<Action<OscMessageValues>, Action<OscCore.OscMessageValues>>();
            }

            _callbacks[address][action] = dlgt;

            return _server.TryAddMethod(address, dlgt);
        }
        
        /// <inheritdoc/>
        public bool RemoveMethod(string address, Action<OscMessageValues> action)
        {
            var dlgt = _callbacks[address][action];

            var result = _server.RemoveMethod(address, dlgt);

            if (result)
            {
                _callbacks[address].Remove(action);
            }

            return result;
        }
        
        /// <inheritdoc/>
        public bool RemoveAddress(string address)
        {

            var result = _server.RemoveAddress(address);

            if (result)
            {
                _callbacks.Remove(address);
            }

            return result;
            
        }

        /// <inheritdoc/>
        public void AddMonitorCallback(MonitorCallback callback)
        {
            var monitorCallback = new OscCore.MonitorCallback((address, values) =>
                callback(address.ToString(), new OscMessageValues(values)));
            _monitorCallbacks[callback] = monitorCallback;
            
            _server.AddMonitorCallback(monitorCallback);
        }
        
        /// <inheritdoc/>
        public bool RemoveMonitorCallback(MonitorCallback callback)
        {

            var result = _server.RemoveMonitorCallback(_monitorCallbacks[callback]);

            if (result)
            {
                _monitorCallbacks.Remove(callback);
            }

            return result;

        }
        
        /// <inheritdoc/>
        public void Dispose()
        {
            _server.Dispose();
        }
 
        ~OscServerService()
        {
            _server.Dispose();
        }
    }
}