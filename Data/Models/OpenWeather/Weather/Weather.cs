using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Weather
{
    public class Weather
    {
        private int _id = 0;
        private string _main = "";
        private string _description = "";
        private string _icon = "";

        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }
        [JsonPropertyName("main")]
        public string Main { get => _main; set => _main = value; }
        [JsonPropertyName("description")]
        public string Description { get => _description; set => _description = value; }
        [JsonPropertyName("icon")]
        public string Icon { get => _icon; set => _icon = value; }
    }
}