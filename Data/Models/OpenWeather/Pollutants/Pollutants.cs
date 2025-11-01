using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Pollutants
{
    public class Pollutants
    {
        private int _dt = 0;

        [JsonPropertyName("main")]
        public required PollutantsMain Main { get; set; }
        [JsonPropertyName("components")]
        public required Components Components { get; set; }
        [JsonPropertyName("dt")]
        public int Dt
        {
            get => _dt;
            set => _dt = value;
        }
    }
}