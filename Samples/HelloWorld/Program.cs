using RadiantPi.Lumagen;

// initialize client
using var client = new RadianceProClient(new RadianceProClientConfig {
    PortName = "/dev/ttyUSB0",
    BaudRate = 9600
});

// show message
await client.ShowMessageAsync("Hellow world!!!", 5);
