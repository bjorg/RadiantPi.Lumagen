# RadiantPi.Lumagen

`RadianceProClient` enables control of a Lumange RadiancePro over a RS-232 connection. The library is platform agnostic, working on Windows or Linux, including on a Raspberry Pi.

## RadiancePro Setup

The client resquires the Lumagen RadiancePro to have Echo enabled:
* MENU → Other → I/O Setup → RS-232 Setup → Echo → On

As well as report mode changes set to Fullv4:
* MENU → Other → I/O Setup → RS-232 Setup → Report mode changes → Fullv4

## Sample: Show Hello World

Use the `ShowMessageAsync()` to show a message on the display.

```csharp
// initialize client
using var client = new RadianceProClient(new RadianceProClientConfig {
    PortName = "/dev/ttyUSB0",
    BaudRate = 9600
});

// show message
Console.WriteLine("Hello World!!!");
await client.ShowMessageAsync("   Hello World!!!   ", 5);
```

## Sample: Listen for events

Use `ModeInfoChanged` to listen to events, such as input or content changes.

```csharp
// hook-up event handler
client.ModeInfoChanged += ShowModeInfo;

// wait until the enter key is pressed
Console.WriteLine("Listening for events. Press ENTER to exit.");
Console.ReadLine();

// remove event handler
client.ModeInfoChanged -= ShowModeInfo;

// function acting on events
void ShowModeInfo(object? sender, ModeInfoChangedEventArgs args) {
    Console.WriteLine("=== MODE INFO ===");
    Console.WriteLine();
    Console.WriteLine(JsonSerializer.Serialize(args.ModeInfo, new JsonSerializerOptions {
        WriteIndented = true
    }));
}
```

# License

This application is distributed under the GNU Affero General Public License v3.0 or later.

Copyright (C) 2020-2021 - Steve G. Bjorg