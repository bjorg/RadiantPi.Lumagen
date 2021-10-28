using System;
using System.Text.Json;
using RadiantPi.Lumagen;

// initialize client
using var client = new RadianceProClient(new RadianceProClientConfig {
    PortName = "/dev/ttyUSB0",
    BaudRate = 9600
});

// hook-up event handler
client.DisplayModeChanged += delegate (object? sender, DisplayModeChangedEventArgs args) {
    Console.WriteLine("=== DISPLAY MODE ===");
    Console.WriteLine();
    Console.WriteLine(JsonSerializer.Serialize(args.DisplayMode, new JsonSerializerOptions {
        WriteIndented = true
    }));
};

// wait until the enter key is pressed
Console.WriteLine("Listening for events. Press ENTER to exit.");
Console.ReadLine();
