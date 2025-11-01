using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Weather
{
    public class Wind
    {
        private double _speed = 0.0;
        private int _deg = 0;
        private double _gust = 0.0;

        [JsonPropertyName("speed")]
        public double Speed
        {
            get => _speed;
            set => _speed = value;
        }
        [JsonPropertyName("deg")]
        public int Deg
        {
            get => _deg;
            set => _deg = value;
        }
        [JsonPropertyName("gust")]
        public double Gust
        {
            get => _gust;
            set => _gust = value;
        }
    }
}