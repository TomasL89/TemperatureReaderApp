using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Forms;

namespace TemperatureLoggerApp
{
    public class ReaderApplicationContext : ApplicationContext, IDisposable
    {
        private readonly TemperatureSensor temperatureSensorView;
        private readonly NotifyIcon notifyIcon;
        private readonly CompositeDisposable disposables;

        public ReaderApplicationContext(IArduinoConnection arduinoTemperatureReader)
        {
            temperatureSensorView = new TemperatureSensor(arduinoTemperatureReader);

            var temperatureLoggerMenuItem = new MenuItem("Connection Settings", new EventHandler(ShowTemperatureLogger));
            var exitTemperatureLoggerMenuItem = new MenuItem("Exit", new EventHandler(ExitApplication));

            disposables = new CompositeDisposable
            {
                arduinoTemperatureReader.MessageReceived.Do(UpdateBalloonMessage).Subscribe(),
            };

            notifyIcon = new NotifyIcon
            {
                Icon = new System.Drawing.Icon("temp cold.ico"),
                ContextMenu = new ContextMenu(new MenuItem[]
            {
                temperatureLoggerMenuItem,
                exitTemperatureLoggerMenuItem
            }),
                Visible = true
            };
        }

        private void UpdateBalloonMessage(MessageData message)
        {
            notifyIcon.Text = $"Temperature: {message.Temperature}°C\nHumidity: {message.Humidity}%\nHeatIndex: {message.HeatIndex}°C";

            if (message.Temperature == -999)
                return;

            if (message.Temperature > 30.0)
                notifyIcon.Icon = new System.Drawing.Icon("temp hot.ico");
            else if (message.Temperature > 20.0 && message.Temperature < 30.0)
                notifyIcon.Icon = new System.Drawing.Icon("temp warm.ico");
            else if (message.Temperature < 20.0)
                notifyIcon.Icon = new System.Drawing.Icon("temp cold.ico");
        }

        private void ExitApplication(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            Application.Exit();
        }

        private void ShowTemperatureLogger(object sender, EventArgs e)
        {
            if (temperatureSensorView.Visible)
            {
                temperatureSensorView.Activate();
            }
            else
            {
                temperatureSensorView.ShowDialog();
            }
        }

        public void Dispose()
        {
            disposables?.Dispose();
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}