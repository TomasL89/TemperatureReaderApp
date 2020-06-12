using System;
using System.IO.Ports;
using System.Reactive.Subjects;

namespace TemperatureLoggerApp
{
    public class ArduinoTemperatureReader : IArduinoConnection
    {
        public IObservable<MessageData> MessageReceived => messageReceived;
        public IObservable<string> ConnectionErrorReceived => connectionErrorReceived;
        public IObservable<bool> ConnectionUpdated => connectionUpdated;

        private SerialPort serialPort;
        private string portName;

        private readonly Subject<MessageData> messageReceived = new Subject<MessageData>();
        private readonly Subject<string> connectionErrorReceived = new Subject<string>();
        private readonly Subject<bool> connectionUpdated = new Subject<bool>();

        private void ConnectToSerial()
        {
            try
            {
                serialPort = new SerialPort
                {
                    PortName = portName,
                    BaudRate = 9600,
                };

                serialPort.Open();
                serialPort.DataReceived += SerialPort_DataReceived;
                connectionUpdated.OnNext(true);
            }
            catch (Exception)
            {
                connectionUpdated.OnNext(false);
                connectionErrorReceived.OnNext($"Could not connect to port {portName}");
            }
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort != null && serialPort.IsOpen)
            {
                var message = serialPort.ReadExisting();
                var messageData = message.Split('_');

                if (messageData.Length != 3)
                {
                    connectionErrorReceived.OnNext($"Did not receive full data, expected 3 messages, got {messageData.Length}");
                    return;
                }

                messageReceived.OnNext(new MessageData(messageData));
            }
        }

        public void UpdateSerialPort(string portName)
        {
            if (!string.IsNullOrWhiteSpace(portName))
            {
                if (serialPort != null)
                {
                    serialPort.Close();
                    serialPort.Dispose();
                    serialPort.DataReceived -= SerialPort_DataReceived;
                }

                this.portName = portName;
                ConnectToSerial();
            }
        }
    }
}