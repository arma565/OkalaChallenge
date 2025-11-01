using Microsoft.AspNetCore.Mvc;
using OkalaChallenge.Data.Services;


namespace OkalaChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController(WeatherApiClientService weatherApiClientService , ILogger<WeatherApiClientService> logger) : ControllerBase
    {
        private readonly WeatherApiClientService _weatherApiClientService = weatherApiClientService;
        private readonly ILogger<WeatherApiClientService> _logger = logger;

        [HttpGet("get/{cityName}")]
        public async Task<IActionResult> GetWeatherDetails(string cityName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cityName))
                    return BadRequest("City name can not be null or empty!");

                var weatherDetails = await _weatherApiClientService.GetWeatherDetails(cityName);
                if (weatherDetails == null)
                    return BadRequest("Couldn't fetch weather details of city!");
                var latitude = 0.0;
                var longitude = 0.0;
                if (weatherDetails.Coord != null) {
                     latitude = weatherDetails.Coord.Lat;
                     longitude = weatherDetails.Coord.Lon;
                }
              
                var weatherPollutantsDetails = await _weatherApiClientService.GetWeatherPollutantsDetails(latitude.ToString(), longitude.ToString());
                if (weatherPollutantsDetails == null)
                    return BadRequest("Couldn't fetch weather pollutants details of city!");

                var city = new
                {
                    Temperature = weatherDetails.Main.Temp,
                    Humidity = weatherDetails.Main.Humidity,
                    WindSpeed = weatherDetails.Wind.Speed,
                    AirQualityIndex = weatherPollutantsDetails.List.First().Main.Aqi,
                    Pollutants = new
                    {
                        CO = weatherPollutantsDetails.List.First().Components.Co,
                        NO = weatherPollutantsDetails.List.First().Components.No,
                        NO2 = weatherPollutantsDetails.List.First().Components.No2,
                        O3 = weatherPollutantsDetails.List.First().Components.O3,
                        SO2 = weatherPollutantsDetails.List.First().Components.So2,
                        PM2_5 = weatherPollutantsDetails.List.First().Components.Pm2_5,
                        PM10 = weatherPollutantsDetails.List.First().Components.Pm10,
                        Nh3 = weatherPollutantsDetails.List.First().Components.Nh3
                    },
                    Latitude = latitude,
                    Longitude = longitude
                   
                };
                return Ok(city);
            }
            catch (NullReferenceException) {
                return StatusCode(404, "NotFound!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Unknown error!");
            }
        }
    }
}
