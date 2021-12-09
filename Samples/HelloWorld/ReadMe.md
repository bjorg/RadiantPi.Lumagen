# RadiantPi.Lumagen - HelloWorld

Display a message on a RadiancePro.

Requires the Lumagen RadiancePro to have Echo enabled:
* MENU → Other → I/O Setup → RS-232 Setup → Echo → On

## Code

```csharp
using System;
using RadiantPi.Lumagen;

// initialize client
using var client = new RadianceProClient(new RadianceProClientConfig {
    PortName = "/dev/ttyUSB0",
    BaudRate = 9600
});

// show message
Console.WriteLine("Hello World!!!");
await client.ShowMessageAsync("   Hello World!!!   ", 5);
```