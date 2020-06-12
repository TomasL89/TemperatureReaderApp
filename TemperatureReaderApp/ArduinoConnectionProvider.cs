namespace TemperatureLoggerApp
{
    public class ArduinoConnectionProvider
    {
        public static IArduinoConnection GetArduinoConnection()
        {
            return new ArduinoTemperatureReader();
        }
    }
}