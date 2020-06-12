using System;

namespace TemperatureLoggerApp
{
    public interface IArduinoConnection
    {
        void UpdateSerialPort(string portNumber);

        IObservable<MessageData> MessageReceived { get; }
        IObservable<string> ConnectionErrorReceived { get; }
        IObservable<bool> ConnectionUpdated { get; }
    }
}