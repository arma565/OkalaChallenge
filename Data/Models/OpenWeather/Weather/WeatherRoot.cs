using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Weather
{
    public class WeatherRoot
    {
        private string _base = "";
        private int _visibility = 0;
        private int _dt = 0;
        private int _timezone = 0;
        private int _id = 0;
        private string _name = "";
        private int _cod = 0;

        public required Coord Coord { get; set; }
        public List<Weather>? Weather { get; set; }
        [JsonPropertyName("base")]
        public string Base { get => _base; set => _base = value; }
        [JsonPropertyName("main")]
        public required WeatherMain Main { get; set; }
        [JsonPropertyName("visibility")]
        public int Visibility { get => _visibility; set => _visibility = value; }
        [JsonPropertyName("wind")]
        public required Wind Wind { get; set; }
        [JsonPropertyName("clouds")]
        public Clouds? Clouds { get; set; }
        [JsonPropertyName("dt")]
        public int Dt { get => _dt; set => _dt = value; }
        [JsonPropertyName("sys")]
        public Sys? Sys { get; set; }
        [JsonPropertyName("timezone")]
        public int TimeZone { get => _timezone; set => _timezone = value; }
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }
        [JsonPropertyName("name")]
        public string Name { get => _name; set => _name = value; }
        [JsonPropertyName("cod")]
        public int Cod { get => _cod; set => _cod = value; }
    }
}