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
