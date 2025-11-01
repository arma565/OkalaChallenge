using Microsoft.AspNetCore.WebUtilities;
using PollutantsRoot = OkalaChallenge.Data.Models.OpenWeather.Pollutants.PollutantsRoot;
using WeatherRoot = OkalaChallenge.Data.Models.OpenWeather.Weather.WeatherRoot;

namespace OkalaChallenge.Data.Services
{
    public class WeatherApiClientService(HttpClient httpClient, IConfiguration config)
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IConfiguration _config = config;

        public async Task<WeatherRoot> GetWeatherDetails(string city) {
            var apiKey = _config["OpenWeather:ApiKey"] ?? throw new InvalidOperationException("API key missing.");
            var weatherQueryParams = new Dictionary<string, string>
            {
                ["q"] = city,
                ["appid"] = apiKey
            };
            var baseUri = _httpClient.BaseAddress ?? throw new InvalidOperationException("HttpClient.BaseAddress is not configured.");
            var weatherUri = QueryHelpers.AddQueryString(new Uri(baseUri, "weather").ToString(), weatherQueryParams!);
            var response = await _httpClient.GetFromJsonAsync<WeatherRoot>(weatherUri) ?? throw new NullReferenceException("Response is null!");
            return response;
        }

        public async Task<PollutantsRoot> GetWeatherPollutantsDetails(string latitude, string longitude)
        {
            var apiKey = _config["OpenWeather:ApiKey"] ?? throw new InvalidOperationException("API key missing.");

            var pollutantQueryParams = new Dictionary<string, string>
            {
                ["lat"] = latitude,
                ["lon"] = longitude,
                ["appid"] = apiKey
            };
            var baseUri = _httpClient.BaseAddress ?? throw new InvalidOperationException("HttpClient.BaseAddress is not configured.");
            var pollutantUri = QueryHelpers.AddQueryString(new Uri(baseUri, "air_pollution").ToString(), pollutantQueryParams!);
            var response = await _httpClient.GetFromJsonAsync<PollutantsRoot>(pollutantUri) ?? throw new NullReferenceException("Response is null!");
            return response;
        }
    }
}
