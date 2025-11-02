using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Weather
{
    public class WeatherMain
    {
        private double _temp;
        private double _feelsLike;
        private double _tempMin;
        private double _tempMax;
        private int _pressure;
        private int _humidity;
        private int _seaLevel;
        private int _grndLevel;

        [JsonPropertyName("temp")]
        public double Temp
        {
            get => _temp;
            set => _temp = value;
        }
        [JsonPropertyName("feels_like")]
        public double FeelsLike
        {
            get => _feelsLike;
            set => _feelsLike = value;
        }
        [JsonPropertyName("temp_min")]
        public double TempMin
        {
            get => _tempMin;
            set => _tempMin = value;
        }
        [JsonPropertyName("temp_max")]
        public double TempMax
        {
            get => _tempMax;
            set => _tempMax = value;
        }
        [JsonPropertyName("pressure")]
        public int Pressure
        {
            get => _pressure;
            set => _pressure = value;
        }
        [JsonPropertyName("humidity")]
        public int Humidity
        {
            get => _humidity;
            set => _humidity = value;
        }
        [JsonPropertyName("sea_level")]
        public int SeaLevel
        {
            get => _seaLevel;
            set => _seaLevel = value;
        }
        [JsonPropertyName("grnd_level")]
        public int GrndLevel
        {
            get => _grndLevel;
            set => _grndLevel = value;
        }
    }
}