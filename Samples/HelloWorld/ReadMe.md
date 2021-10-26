# RadiantPi.Lumagen - ShowModeInfo

Display a message on a RadiancePro.

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

# License

This application is distributed under the GNU Affero General Public License v3.0 or later.

Copyright (C) 2020-2021 - Steve G. Bjorg