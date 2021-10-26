using System;
using System.Text.Json;
using RadiantPi.Lumagen;

// initialize client
using var client = new RadianceProClient(new RadianceProClientConfig {
    PortName = "/dev/ttyUSB0",
    BaudRate = 9600
});

// hook-up event handler showing the mode info events
client.ModeInfoChanged += ShowModeInfo;

// wait until the enter is pressed
Console.ReadLine();

// remove event handler again befor exiting
client.ModeInfoChanged -= ShowModeInfo;

// function acting on mode info changed events
void ShowModeInfo(object? sender, ModeInfoChangedEventArgs args) {
    Console.WriteLine("=== MODE INFO ===");
    Console.WriteLine(JsonSerializer.Serialize(args.ModeInfo, new JsonSerializerOptions {
        WriteIndented = true
    }));
    Console.WriteLine();
}