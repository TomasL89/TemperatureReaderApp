using System;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace TemperatureLoggerApp
{
    public partial class TemperatureSensor : Form, IDisposable
    {
        private readonly IArduinoConnection arduinoConnection;
        private string portNumber;
        private CompositeDisposable disposables;

        public TemperatureSensor(IArduinoConnection arduinoConnection)
        {
            InitializeComponent();

            string[] ports = SerialPort.GetPortNames();
            portsDropDown.Items.AddRange(ports);

            if (ports.Length > 0)
                portsDropDown.SelectedItem = ports.First();

            this.arduinoConnection = arduinoConnection;
            disposables = new CompositeDisposable
            {
                arduinoConnection.ConnectionErrorReceived.Do(DisplayErrorMessage).Subscribe(),
                arduinoConnection.ConnectionUpdated.Do(HandleConnectionUpdated).Subscribe()
            };
        }

        private void HandleConnectionUpdated(bool isConnected)
        {
            if (isConnected)
            {
                errorSymbol.Image = null;
                errorSymbol.Visible = false;
                errorMessageTextBox.Visible = false;
                errorMessageTextBox.Text = string.Empty;
            }
        }

        private void DisplayErrorMessage(string message)
        {
            errorSymbol.Visible = true;
            errorSymbol.Image = SystemIcons.Error.ToBitmap();
            errorMessageTextBox.Visible = true;
            errorMessageTextBox.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(portNumber))
                arduinoConnection.UpdateSerialPort(portNumber);
        }

        private void portsDropDown_SelectedValueChanged(object sender, EventArgs e)
        {
            portNumber = portsDropDown.SelectedItem.ToString();
        }

        public void Dispose()
        {
            disposables?.Dispose();
        }
    }
}