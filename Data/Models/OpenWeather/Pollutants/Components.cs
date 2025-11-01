
using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Pollutants
{
    public class Components
    {
        private double _co = 0.0;
        private double _no = 0.0;
        private double _no2 = 0.0;
        private double _o3 = 0.0;
        private double _so2 = 0.0;
        private double _pm2_5 = 0.0;
        private double _pm10 = 0.0;
        private double _nh3 = 0.0;

        [JsonPropertyName("co")]
        public double Co { get => _co; set => _co = value; }
        [JsonPropertyName("no")]
        public double No { get => _no; set => _no = value; }
        [JsonPropertyName("no2")]
        public double No2 { get => _no2; set => _no2 = value; }
        [JsonPropertyName("o3")]
        public double O3 { get => _o3; set => _o3 = value; }
        [JsonPropertyName("so2")]
        public double So2 { get => _so2; set => _so2 = value; }
        [JsonPropertyName("pm2_5")]
        public double Pm2_5 { get => _pm2_5; set => _pm2_5 = value; }
        [JsonPropertyName("pm10")]
        public double Pm10 { get => _pm10; set => _pm10 = value; }
        [JsonPropertyName("nh3")]
        public double Nh3 { get => _nh3; set => _nh3 = value; }
    }
}
