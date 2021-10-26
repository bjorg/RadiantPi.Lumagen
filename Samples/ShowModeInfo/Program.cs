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
    Console.WriteLine(JsonSerializer.Serialize(args.ModeInfo, new JsonSerializerOptions {
        WriteIndented = true
    }));
    Console.WriteLine();
}