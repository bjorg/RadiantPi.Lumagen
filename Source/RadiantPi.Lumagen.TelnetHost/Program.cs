/*

1. Open COM connection to Lumagen RadiancePro
2. Start listening for Telnet connections
3. Start session listener per Telnet connection
4. Serialize commands to COM port for each connection
5. Echo COM messages to all open Telnet connections

*/

using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using RadiantPi.Lumagen;

// initialize client
using RadianceProClient client = new(new RadianceProClientConfig {
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


internal class SerialPortDataArgs {

    //--- Constructors ---
    public SerialPortDataArgs(string data) => Data = data ?? throw new ArgumentNullException(nameof(data));

    //--- Properties ---
    public string Data { get; }
}

internal class SerialPortActor : IDisposable {

    //--- Class Methods ---
    private static string Escape(string text)
        => string.Join("", text.Select(c => c switch {
            >= (char)32 and < (char)127 => ((char)c).ToString(),
            '\n' => "\\n",
            '\r' => "\\r",
            _ => $"\\u{(int)c:X4}"
        }));

    //--- Fields ---
    private readonly SerialPort _serialPort;
    private readonly SemaphoreSlim _mutex = new(1, 1);
    private readonly ILogger? _logger;
    private bool _disposed;

    //--- Constructors ---
    public SerialPortActor(SerialPort serialPort, ILogger? logger = null) {
        _logger = logger;
        _serialPort = serialPort ?? throw new ArgumentNullException(nameof(serialPort));
        _serialPort.DataReceived += SerialDataReceived;
        _serialPort.Open();
        _logger?.LogInformation("Serial port is open");
    }

    //--- Events ---
    public event EventHandler<SerialPortDataArgs>? SerialPortDataReceived;

    //--- Methods ---
    public void Dispose() {
        _serialPort.DataReceived -= SerialDataReceived;
        _disposed = true;
        _mutex.Dispose();
        if(_serialPort.IsOpen) {
            _logger?.LogInformation("Closing serial port");
            _serialPort.DiscardInBuffer();
            _serialPort.DiscardOutBuffer();
            _serialPort.Close();
        } else {
            _logger?.LogDebug("Serial port is already closed");
        }
        _serialPort.Dispose();
    }

    private async Task SendAsync(string command) {
        CheckNotDisposed();
        var buffer = Encoding.UTF8.GetBytes(command);
        await _mutex.WaitAsync().ConfigureAwait(false);
        try {
            _logger?.LogTrace($"Sending command: '{Escape(command)}'");
            await _serialPort.BaseStream.WriteAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
        } finally {
            _mutex.Release();
        }
    }

    private void SerialDataReceived(object sender, SerialDataReceivedEventArgs args) {
        var received = _serialPort.ReadExisting();
        _logger?.LogTrace($"Received data: '{Escape(received)}'");
        SerialPortDataReceived?.Invoke(this, new(received));
    }

    private void CheckNotDisposed() {
        if(_disposed) {
            throw new ObjectDisposedException("client was disposed");
        }
    }
}