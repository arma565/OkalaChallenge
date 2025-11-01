
using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Pollutants
{
    public class Coord
    {
        private double _lon = 0.0;
        private double _lat = 0.0;

        [JsonPropertyName("lon")]
        public double Lon
        {
            get => _lon;
            set => _lon = value;
        }
        [JsonPropertyName("lat")]
        public double Lat
        {
            get => _lat;
            set => _lat = value;
        }
    }
}
