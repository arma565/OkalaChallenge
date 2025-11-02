using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Weather
{
    public class Clouds
    {
        private int _all;

        [JsonPropertyName("all")]
        public int All
        {
            get => _all;
            set => _all = value;
        }
    }
}