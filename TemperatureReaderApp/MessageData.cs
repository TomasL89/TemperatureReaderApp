namespace TemperatureLoggerApp
{
    public class MessageData
    {
        public float Temperature { get; }
        public float Humidity { get; }
        public float HeatIndex { get; }

        public MessageData(string[] messageData)
        {
            float temperature = -999;
            float.TryParse(messageData[0], out temperature);
            Temperature = temperature;

            float humidity = -999;
            float.TryParse(messageData[1], out humidity);
            Humidity = humidity;

            float heatIndex = -999;
            float.TryParse(messageData[2], out heatIndex);
            HeatIndex = heatIndex;
        }
    }
}