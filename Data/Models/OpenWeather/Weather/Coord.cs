using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Weather
{
    public class Coord
    {
        private double _lon;
        private double _lat;


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