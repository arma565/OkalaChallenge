using System.Text.Json.Serialization;

namespace OkalaChallenge.Data.Models.OpenWeather.Pollutants
{
    public class PollutantsRoot
    {
        private List<PollutantsList> _list = [];
        private Coord _coord = new();

        [JsonPropertyName("coord")]
        public Coord Coord
        {
            get => _coord;
            set => _coord = value;
        }
        [JsonPropertyName("list")]
        public List<PollutantsList> List
        {
            get => _list;
            set => _list = value;
        }
    }
}