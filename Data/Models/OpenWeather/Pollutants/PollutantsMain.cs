using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Pollutants
{
    public class PollutantsMain
    {
        private int _aqi = 0;

        [JsonPropertyName("aqi")]
        public int Aqi
        {
            get => _aqi;
            set => _aqi = value;
        }
    }
}