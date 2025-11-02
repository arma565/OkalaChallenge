using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OkalaChallenge.Data.Services;


namespace OkalaChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController(WeatherApiClientService weatherApiClientService , TechnicalQuestionsService interviewResponseService) : ControllerBase
    {
        private readonly WeatherApiClientService _weatherApiClientService = weatherApiClientService;
        private readonly TechnicalQuestionsService _interviewResponseService = interviewResponseService;
        [HttpGet("get/city/{cityName}")]
        public async Task<IActionResult> GetWeatherDetails(string cityName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(cityName))
                    return BadRequest(new { error = "City name can not be null or empty!" });

                var weatherDetails = await _weatherApiClientService.GetWeatherDetails(cityName);
                if (weatherDetails == null)
                    return BadRequest(new { error = "Couldn't fetch weather details of city!" });

                var latitude = weatherDetails.Coord.Lat;
                var longitude = weatherDetails.Coord.Lon;

                var weatherPollutantsDetails = await _weatherApiClientService.GetWeatherPollutantsDetails(latitude.ToString(), longitude.ToString());
                if (weatherPollutantsDetails == null)
                    return BadRequest(new { error = "Couldn't fetch weather pollutants details of city!" });

                var first = weatherPollutantsDetails.List?.FirstOrDefault();

                var city = new
                {
                    Temperature = weatherDetails.Main?.Temp,
                    Humidity = weatherDetails.Main?.Humidity,
                    WindSpeed = weatherDetails.Wind?.Speed,
                    AirQualityIndex = first?.Main?.Aqi,
                    Pollutants = first?.Components == null ? null : new
                    {
                        CO = first.Components.Co,
                        NO = first.Components.No,
                        NO2 = first.Components.No2,
                        O3 = first.Components.O3,
                        SO2 = first.Components.So2,
                        PM2_5 = first.Components.Pm2_5,
                        PM10 = first.Components.Pm10,
                        Nh3 = first.Components.Nh3
                    },
                    Latitude = latitude,
                    Longitude = longitude
                };
                return Ok(city);
            }
            catch (NullReferenceException) {
                return NotFound("NotFound!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Uknown system error!");
            }
        }

        [HttpGet("get/technical")]
        public IActionResult GetTechnicalQuestionsResult() {
            var result = _interviewResponseService.GetTechnicalQuestionsResult();
            return Ok(result);
        }
    }
}
