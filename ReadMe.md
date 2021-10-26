# RadiantPi.Lumagen

`RadianceProClient` enables control of a Lumagen RadiancePro over a RS-232 connection. The library is platform agnostic and works on Windows or Linux, including on a Raspberry Pi.

Run the `dotnet` command from your project folder to add the `RadiantPi.Lumagen` assembly:
```
dotnet add package RadiantPi.Lumagen
```

Find a description of the latest changes in the [release notes](ReleaseNotes.md).

## RadiancePro Setup

`RadianceProClient` requires the Lumagen RadiancePro to have Echo enabled:
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
await client.ShowMessageAsync("Hello World!!!", 5);
```

## Sample: Listen for events

Use `DisplayModeChanged` to listen to events, such as input or content changes.

```csharp
// hook-up event handler
client.DisplayModeChanged += ShowDisplayMode;

// wait until the enter key is pressed
Console.ReadLine();

// remove event handler
client.DisplayModeChanged -= ShowDisplayMode;

// function acting on events
void ShowDisplayMode(object? sender, DisplayModeChangedEventArgs args) {
    Console.WriteLine("=== DISPLAY MODE ===");
    Console.WriteLine(JsonSerializer.Serialize(args.DisplayMode, new JsonSerializerOptions {
        WriteIndented = true
    }));
}
```

# License

This application is distributed under the GNU Affero General Public License v3.0 or later.

Copyright (C) 2020-2021 - Steve G. Bjorg