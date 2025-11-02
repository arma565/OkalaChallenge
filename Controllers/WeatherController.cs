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
                var latitude = weatherDetails.Coord.Lat;
                var longitude = weatherDetails.Coord.Lon;

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
                    Longitude = longitude,
                    TechnicalQuestions = "1.How much time did you spend on this task? 1 day and half,\n " +
                    "If you had more time, what improvements or additions would you make? i'm not sure, maybe more details about the city, for example Area, Population, \n" +
                    "2.What is the most useful feature recently added to your favorite programming language? upload and download image to the api \n" +
                    "Please include a code snippet to demonstrate how you use it => i can share it via github or source code of project through whats app \n" +
                    "3.How do you identify and diagnose a performance issue in a production environment? i did not use them but i know i must use profiler tools \n" +
                    "4.What’s the last technical book you read or technical conference you attended? Data structure,Algorithm design and Software Engineering \n" +
                    "What did you learn from it? Data structure: lists,Queue,Arrays,Graph,Tree,Stack,Linked list etc. Algorithm design: design methods like Divide and Conquer or Greedy Method etc. \n" +
                    "What’s your opinion about this technical test? i've learned some technical things like tests and OpenWeatherMap website apis because i had no exprience in them before, its great to see if i dont know something try to learn it."
                    

                };
                return Ok(city);
            }
            catch (NullReferenceException) {
                return StatusCode(404, "NotFound!");
            }
            catch (Exception)
            {
                return StatusCode(500, "Uknown system error!");
            }
        }
    }
}
