using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Pollutants
{
    public class PollutantsList
    {
        private PollutantsMain _main = new();
        private Components _components = new();
        private int _dt = 0;


        [JsonPropertyName("main")]
        public PollutantsMain Main
        {
            get => _main;
            set => _main = value;
        }
        [JsonPropertyName("components")]
        public Components Components
        {
            get => _components;
            set => _components = value;
        }
        [JsonPropertyName("dt")]
        public int Dt
        {
            get => _dt;
            set => _dt = value;
        }
    }
}