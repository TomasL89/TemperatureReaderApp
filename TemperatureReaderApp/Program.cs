using System;
using System.Windows.Forms;

namespace TemperatureLoggerApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            IArduinoConnection arduinoTemperatureReader = ArduinoConnectionProvider.GetArduinoConnection();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReaderApplicationContext(arduinoTemperatureReader));
        }
    }
}