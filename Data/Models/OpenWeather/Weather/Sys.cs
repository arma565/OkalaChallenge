using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Weather
{
    public class Sys
    {
        private int _type = 0;
        private int _id = 0;
        private string _country = "";
        private int _sunrise = 0;
        private int _sunset = 0;

        [JsonPropertyName("type")]
        public int Type { get => _type; set => _type = value; }
        [JsonPropertyName("id")]
        public int Id { get => _id; set => _id = value; }
        [JsonPropertyName("country")]
        public string Country { get => _country; set => _country = value; }
        [JsonPropertyName("sunrise")]
        public int Sunrise { get => _sunrise; set => _sunrise = value; }
        [JsonPropertyName("sunset")]
        public int Sunset { get => _sunset; set => _sunset = value; }
    }
}