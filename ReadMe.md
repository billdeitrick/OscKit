# OscKit

A lightweight, dependency-injection friendly .NET library for working with Open Sound Control (OSC) messages. Built on top of [OscCore](https://github.com/billdeitrick/OscCore), OscKit provides clean abstractions and interfaces that make it easy to build testable and maintainable applications using OSC for real-time communication.

## Features

- 🎯 **Clean Abstractions** - Simple, focused interfaces for OSC client and server functionality
- 💉 **Dependency Injection Ready** - First-class support for .NET dependency injection containers
- 🧪 **Testable** - Interface-based design makes unit testing straightforward
- 🚀 **Flexible** - Use with DI or create instances directly via factory methods
- 📦 **Comprehensive Type Support** - Full support for all OSC data types (int, float, string, blob, timestamp, MIDI, color, and more)
- 🎛️ **Targeted Framework** - .NET Standard 2.1

## Installation

Install via NuGet Package Manager:

```bash
dotnet add package Buildetech.OscKit
```

Or via the NuGet Package Manager Console:

```powershell
Install-Package Buildetech.OscKit
```

## Quick Start

### Using Dependency Injection (Recommended)

#### Registering Services

```csharp
using Buildetech.OscKit;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();

// Register an OSC client (sends messages)
services.AddOscClientService("192.168.1.100", 9000);

// Register an OSC server (receives messages)
services.AddOscServerService(8000);

var provider = services.BuildServiceProvider();
```

#### Using the OSC Client

```csharp
using Buildetech.OscKit.Services;

public class MyService
{
    private readonly IOscClientService _oscClient;

    public MyService(IOscClientService oscClient)
    {
        _oscClient = oscClient;
    }

    public void SendMessage()
    {
        // Send various types of messages
        _oscClient.Send("/volume", 0.75f);
        _oscClient.Send("/track/name", "My Song");
        _oscClient.Send("/position", 42);

        // Send multiple values
        _oscClient.Send("/track/info", new IOscWriteable[]
        {
            new OscString("Song Title"),
            new OscInt(120), // BPM
            new OscFloat(3.5f) // Duration in minutes
        });
    }
}
```

#### Using the OSC Server

```csharp
using Buildetech.OscKit.Services;

public class MyOscHandler
{
    private readonly IOscServerService _oscServer;

    public MyOscHandler(IOscServerService oscServer)
    {
        _oscServer = oscServer;
        RegisterHandlers();
    }

    private void RegisterHandlers()
    {
        // Listen for messages at specific addresses
        _oscServer.TryAddMethod("/volume", HandleVolume);
        _oscServer.TryAddMethod("/track/name", HandleTrackName);

        // Monitor all incoming messages
        _oscServer.AddMonitorCallback((address, values) =>
        {
            Console.WriteLine($"Received message at {address}");
        });
    }

    private void HandleVolume(OscMessageValues values)
    {
        float volume = values.ReadFloatElement(0);
        Console.WriteLine($"Volume set to: {volume}");
    }

    private void HandleTrackName(OscMessageValues values)
    {
        string trackName = values.ReadStringElement(0);
        Console.WriteLine($"Track name: {trackName}");
    }
}
```

### Using Factory Methods (Without DI)

If you prefer not to use dependency injection, you can create instances directly using the factory:

```csharp
using Buildetech.OscKit;

// Create the factory
var factory = new OscServiceFactory();

// Create an OSC client
var client = factory.CreateClient("192.168.1.100", 9000);
client.Send("/test", "Hello OSC!");

// Create an OSC server
var server = factory.CreateServer(8000);
server.TryAddMethod("/test", values =>
{
    string message = values.ReadStringElement(0);
    Console.WriteLine($"Received: {message}");
});

// Don't forget to dispose when done
client.Dispose();
server.Dispose();
```

### Direct Instantiation

You can also instantiate services directly:

```csharp
using Buildetech.OscKit.Services;

// Create client directly
using var client = new OscClientService("192.168.1.100", 9000);
client.Send("/hello", "world");

// Create server directly
using var server = new OscServerService(8000);
server.TryAddMethod("/hello", values =>
{
    Console.WriteLine($"Message: {values.ReadStringElement(0)}");
});
```

## Supported OSC Data Types

OscKit supports all standard OSC data types:

- **Primitives**: `int`, `float`, `double`, `long`, `string`, `char`, `bool`
- **OSC Types**: `OscInt`, `OscFloat`, `OscDouble`, `OscLong`, `OscString`, `OscChar`, `OscTrue`, `OscFalse`
- **Special Types**: `OscNil`, `OscInfinitum`, `OscTimestamp`, `OscColor32`, `OscMidiMessage`
- **Binary Data**: `OscByteArray` (blobs)
- **Timestamps**: `DateTime` (automatically converted to OSC timestamps)

## API Overview

### IOscClientService

The client service provides overloaded `Send()` methods for all supported data types:

```csharp
void Send(string address);
void Send(string address, int element);
void Send(string address, float element);
void Send(string address, string element);
void Send(string address, IOscWriteable[] elements);
// ... and many more overloads for all OSC types
```

### IOscServerService

The server service provides methods to register callbacks for specific OSC addresses:

```csharp
bool TryAddMethod(string address, Action<OscMessageValues> action);
bool RemoveMethod(string address, Action<OscMessageValues> action);
bool RemoveAddress(string address);
void AddMonitorCallback(MonitorCallback callback);
bool RemoveMonitorCallback(MonitorCallback callback);
```

### IOscServiceFactory

The factory provides simple creation methods:

```csharp
IOscClientService CreateClient(string address, int port);
IOscServerService CreateServer(int port);
```

## Examples

### Sending Complex Messages

```csharp
// Send a complex message with multiple parameters
client.Send("/synth/note", new IOscWriteable[]
{
    new OscString("C4"),           // Note name
    new OscInt(60),                // MIDI note number
    new OscFloat(0.8f),            // Velocity
    new OscDouble(2.5)             // Duration
});
```

### Pattern Matching with Wildcards

```csharp
// Listen to all messages under /track/*
server.TryAddMethod("/track/*", values =>
{
    // Handle any track-related message
});
```

### Monitor All Traffic

```csharp
// Log all incoming OSC messages
server.AddMonitorCallback((address, values) =>
{
    Console.WriteLine($"[{DateTime.Now}] {address}: {values.ElementCount} elements");
});
```

## Best Practices

1. **Use Dependency Injection** - Leverage the built-in DI extensions for better testability
2. **Dispose Properly** - Always dispose of client and server instances when done
3. **Error Handling** - Wrap OSC operations in try-catch blocks for production code
4. **Thread Safety** - OSC servers run on background threads; ensure callbacks are thread-safe

## Contributing

Contributions are welcome! Please feel free to submit issues or pull requests on [GitHub](https://github.com/billdeitrick/OscKit).

## License

See the LICENSE file in the repository for license information.

## Related Projects

- [OscCore](https://github.com/billdeitrick/OscCore) - The underlying OSC protocol implementation

## About OSC

Open Sound Control (OSC) is a protocol for communication among computers, sound synthesizers, and other multimedia devices. It's widely used in music production, VJing, live coding, and interactive installations.

Learn more at [opensoundcontrol.org](http://opensoundcontrol.org/)
