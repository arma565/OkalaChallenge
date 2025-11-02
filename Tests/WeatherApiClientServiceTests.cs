using Moq;
using Moq.Protected;
using OkalaChallenge.Data.Models.OpenWeather.Pollutants;
using OkalaChallenge.Data.Models.OpenWeather.Weather;
using OkalaChallenge.Data.Services;
using System.Net;
using Xunit;

namespace OkalaChallenge.Tests
{
    public class WeatherApiClientServiceTests
    {
        private readonly Uri _baseAddress = new("https://api.openweathermap.org/data/2.5/");

        private HttpClient CreateClient(HttpMessageHandler handler)
        {
            var client = new HttpClient(handler) { BaseAddress = _baseAddress };
            return client;
        }

        private WeatherApiClientService BuildService(HttpClient httpClient, IConfiguration config)
        {
            return new WeatherApiClientService(httpClient, config);
        }

        // --------------------------------------------------------------
        // 1. GetWeatherDetails – success
        // --------------------------------------------------------------
        [Fact]
        public async Task GetWeatherDetails_ReturnsObject_WhenApiOk()
        {
            // Arrange
            var city = "Berlin";
            var apiKey = "test-key-123";
            var expected = new WeatherRoot();

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(expected)
                })
                .Verifiable();

            var httpClient = CreateClient(handlerMock.Object);

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new KeyValuePair<string, string?>[]
                {
                    new KeyValuePair<string, string?>("OpenWeather:ApiKey", apiKey)
                })
                .Build();

            var service = BuildService(httpClient, config);

            // Act
            var result = await service.GetWeatherDetails(city);

            // Assert
            Assert.Equal(expected.Id, result.Id);

            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri!.ToString().Contains($"q={city}") &&
                    req.RequestUri!.ToString().Contains($"appid={apiKey}")),
                ItExpr.IsAny<CancellationToken>());
        }

        // --------------------------------------------------------------
        // 2. GetWeatherDetails – missing API key
        // --------------------------------------------------------------
        [Fact]
        public async Task GetWeatherDetails_ThrowsInvalidOperationException_WhenApiKeyMissing()
        {
            var httpClient = new HttpClient { BaseAddress = _baseAddress };
            var config = new ConfigurationBuilder().Build(); // no key

            var service = BuildService(httpClient, config);

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetWeatherDetails("Paris"));

            Assert.Equal("API key missing.", ex.Message);
        }

        // --------------------------------------------------------------
        // 3. GetWeatherPollutantsDetails – success
        // --------------------------------------------------------------
        [Fact]
        public async Task GetWeatherPollutantsDetails_ReturnsObject_WhenApiOk()
        {
            // Arrange
            var lat = "52.52";
            var lon = "13.41";
            var apiKey = "test-key-123";
            var expected = new PollutantsRoot();

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = JsonContent.Create(expected)
                });

            var httpClient = CreateClient(handlerMock.Object);

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new KeyValuePair<string, string?>[]
                {
                    new KeyValuePair<string, string?>("OpenWeather:ApiKey", apiKey)
                })
                .Build();

            var service = BuildService(httpClient, config);

            // Act
            var result = await service.GetWeatherPollutantsDetails(lat, lon);

            // Assert
            Assert.Equal(expected.List, result.List);

            handlerMock.Protected().Verify(
                "SendAsync",
                Times.Once(),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri!.ToString().Contains($"lat={lat}") &&
                    req.RequestUri!.ToString().Contains($"lon={lon}") &&
                    req.RequestUri!.ToString().Contains($"appid={apiKey}")),
                ItExpr.IsAny<CancellationToken>());
        }

        // --------------------------------------------------------------
        // 4. GetWeatherPollutantsDetails – 404 → null → NullReferenceException
        // --------------------------------------------------------------
        [Fact]
        public async Task GetWeatherPollutantsDetails_ThrowsNullReference_WhenNotFound()
        {
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.NotFound));

            var httpClient = CreateClient(handlerMock.Object);

            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new KeyValuePair<string, string?>[]
                {
                    new KeyValuePair<string, string?>("OpenWeather:ApiKey", "key")
                })
                .Build();

            var service = BuildService(httpClient, config);

            await Assert.ThrowsAsync<HttpRequestException>(
                () => service.GetWeatherPollutantsDetails("0", "0"));
        }

        // --------------------------------------------------------------
        // 5. BaseAddress missing
        // --------------------------------------------------------------
        [Fact]
        public async Task GetWeatherDetails_ThrowsInvalidOperationException_WhenBaseAddressNull()
        {
            var httpClient = new HttpClient(); // no BaseAddress
            var config = new ConfigurationBuilder()
                .AddInMemoryCollection(new KeyValuePair<string, string?>[]
                {
                    new KeyValuePair<string, string?>("OpenWeather:ApiKey", "key")
                })
                .Build();

            var service = BuildService(httpClient, config);

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.GetWeatherDetails("London"));

            Assert.Equal("HttpClient.BaseAddress is not configured.", ex.Message);
        }
    }
}
