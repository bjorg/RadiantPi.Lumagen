# RadiantPi.Lumagen - ShowModeInfo

List for mode changes and show the results.

Requires the Lumagen RadiancePro to have report mode changes set to Fullv4:
* MENU → Other → I/O Setup → RS-232 Setup → Report mode changes → Fullv4

## Code
```csharp
using System;
using System.Text.Json;
using RadiantPi.Lumagen;

// initialize client
using var client = new RadianceProClient(new RadianceProClientConfig {
    PortName = "/dev/ttyUSB0",
    BaudRate = 9600
});

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

## Output
```
Listening for events. Press ENTER to exit.

=== MODE INFO ===
{
  "InputStatus": 2,
  "VirtualInputSelected": 1,
  "PhysicalInputSelected": 1,
  "SourceVerticalRate": "023",
  "SourceVerticalResolution": "2160",
  "SourceVideoMode": 3,
  "Source3DMode": 1,
  "SourceRasterAspectRatio": "178",
  "SourceContentAspectRatio": "220",
  "SourceDynamicRange": 2,
  "ActiveInputConfigNumber": "0",
  "OutputNonLinearStretchActive": false,
  "Output3DMode": 1,
  "OutputEnabled": 10,
  "OutputCms": 2,
  "OutputStyle": 1,
  "OutputVerticalRate": "023",
  "OutputVerticalResolution": "2160",
  "OutputVideoMode": 3,
  "OutputAspectRatio": "178",
  "OutputColorSpace": 3,
  "DetectedAspectRatio": "178",
  "DetectedRasterAspectRatio": "178"
}
```