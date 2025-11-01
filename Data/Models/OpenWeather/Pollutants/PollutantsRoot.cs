using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Pollutants
{
    public class PollutantsRoot
    {
        private List<Pollutants> _list = [];

        [JsonPropertyName("coord")]
        public Coord? Coord { get; set; }
        [JsonPropertyName("list")]
        public List<Pollutants> List { get => _list; set => _list = value; }
    }
}