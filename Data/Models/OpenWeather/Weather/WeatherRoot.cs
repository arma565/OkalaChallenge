using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Weather
{
    public class WeatherRoot
    {
        private Coord _coord = new();
        private List<Weather> _weatherList = [];
        private string _base = "";
        private WeatherMain _main = new();
        private int _visibility = 0;
        private Wind _wind = new();
        private Clouds _clouds = new();
        private int _dt = 0;
        private Sys _sys = new();
        private int _timezone = 0;
        private int _id = 0;
        private string _name = "";
        private int _cod = 0;

        [JsonPropertyName("coord")]
        public Coord Coord
        {
            get => _coord;
            set => _coord = value;
        }
        [JsonPropertyName("weather")]
        public List<Weather> WeatherList
        {
            get => _weatherList;
            set => _weatherList = value;
        }
        [JsonPropertyName("base")]
        public string Base
        {
            get => _base;
            set => _base = value;
        }
        [JsonPropertyName("main")]
        public WeatherMain Main
        {
            get => _main;
            set => _main = value;
        }
        [JsonPropertyName("visibility")]
        public int Visibility
        {
            get => _visibility;
            set => _visibility = value;
        }
        [JsonPropertyName("wind")]
        public Wind Wind
        {
            get => _wind;
            set => _wind = value;
        }
        [JsonPropertyName("clouds")]
        public Clouds Clouds
        {
            get => _clouds;
            set => _clouds = value;
        }
        [JsonPropertyName("dt")]
        public int Dt
        {
            get => _dt;
            set => _dt = value;
        }
        [JsonPropertyName("sys")]
        public Sys Sys
        {
            get => _sys;
            set => _sys = value;
        }
        [JsonPropertyName("timezone")]
        public int TimeZone
        {
            get => _timezone;
            set => _timezone = value;
        }
        [JsonPropertyName("id")]
        public int Id
        {
            get => _id;
            set => _id = value;
        }
        [JsonPropertyName("name")]
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        [JsonPropertyName("cod")]
        public int Cod
        {
            get => _cod;
            set => _cod = value;
        }
    }
}