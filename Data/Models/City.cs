
using OkalaChallenge.Data.Models.OpenWeather.Pollutants;

namespace OkalaChallenge.Data.Models
{
    public class City
    {
        private int _temperature = 0;
        private int _humidity = 0;
        private int _windSpeed = 0;
        private int _aqi = 0;
        private double _latitude;
        private double _longitude;
        private PollutantsRoot? _pollutants;

        public int Temperature
        {
            get => _temperature;
            set => _temperature = value;
        }
        public int Humidity
        {
            get => _humidity;
            set => _humidity = value;
        }
        public int WindSpeed
        {
            get => _windSpeed;
            set => _windSpeed = value;
        }
        public int AQI
        {
            get => _aqi;
            set => _aqi = value;
        }
        public double Latitude
        {
            get => _latitude;
            set => _latitude = value;
        }
        public double Longitude
        {
            get => _longitude;
            set => _longitude = value;
        }
        public PollutantsRoot? Pollutants
        {
            get => _pollutants;
            set => _pollutants = value;
        }
    }
}
