using Microsoft.AspNetCore.WebUtilities;
using PollutantsRoot = OkalaChallenge.Data.Models.OpenWeather.Pollutants.PollutantsRoot;
using WeatherRoot = OkalaChallenge.Data.Models.OpenWeather.Weather.WeatherRoot;



namespace OkalaChallenge.Data.Services
{
    public class WeatherApiClientService(HttpClient httpClient, IConfiguration config,ILogger<WeatherApiClientService> logger)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _config = config;
        private readonly ILogger<WeatherApiClientService> _logger = logger;
        
        

        public async Task<WeatherRoot> GetWeatherDetails(string city) {
            var apiKey = _config["OpenWeather:ApiKey"] ?? throw new InvalidOperationException("API key missing.");
            var baseUri = _config["OpenWeather:BaseUrl"] ?? throw new InvalidOperationException("Base URI missing.");
            var baseAddress = new Uri(baseUri);
            var weatherQueryParams = new Dictionary<string, string>
            {
                ["q"] = city,
                ["appid"] = apiKey
            };
            var weatherUri = QueryHelpers.AddQueryString($"{baseAddress}weather", weatherQueryParams!);
            var response = await _httpClient.GetFromJsonAsync<WeatherRoot>(weatherUri) ?? throw new NullReferenceException("Response is null!");
            return response;
        }

        public async Task<PollutantsRoot> GetWeatherPollutantsDetails(string latitude, string longitude)
        {
            var apiKey = _config["OpenWeather:ApiKey"] ?? throw new InvalidOperationException("API key missing.");
            var baseUri = _config["OpenWeather:BaseUrl"] ?? throw new InvalidOperationException("Base URI missing.");
            var baseAddress = new Uri(baseUri);
            var pollutantQueryParams = new Dictionary<string, string>
            {
                ["lat"] = latitude,
                ["lon"] = longitude,
                ["appid"] = apiKey
            };
            var pollutantUri = QueryHelpers.AddQueryString($"{baseAddress}air_pollution", pollutantQueryParams!);
            var response = await _httpClient.GetFromJsonAsync<PollutantsRoot>(pollutantUri) ?? throw new NullReferenceException("Response is null!");
            return response;
        }


    }
}
