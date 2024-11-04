using Xunit;
using Moq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using IASI.Equipamentos.Application.Services;
using IASI.Equipamentos.Domain.Dtos;
using FluentAssertions;
using Moq.Protected;

namespace IASI.Equipamentos.Test
{
    public class CarbonServiceTests
    {
        private readonly Mock<HttpClient> _httpClientMock;
        private readonly CarbonService _carbonService;
        private readonly Mock<IConfiguration> _configurationMock;
        private readonly Mock<ILogger<CarbonService>> _loggerMock;

        public CarbonServiceTests()
        {
            _httpClientMock = new Mock<HttpClient>();
            _configurationMock = new Mock<IConfiguration>();
            _loggerMock = new Mock<ILogger<CarbonService>>();

            _configurationMock.Setup(c => c["ExternalServices:CarbonInterfaceApi:ApiKey"])
                .Returns("your-api-key");
            _configurationMock.Setup(c => c["ExternalServices:CarbonInterfaceApi:BaseUrl"])
                .Returns("https://www.carboninterface.com/api/v1/");

            _carbonService = new CarbonService(_httpClientMock.Object, _configurationMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task CalculateElectricityEmissionsAsync_ShouldReturnValidCarbonEstimateResponse()
        {
            // Arrange
            var expectedResponse = new CarbonEstimateResponse
            {
                Data = new DataResponse
                {
                    Id = "test-id",
                    Type = "estimate",
                    Attributes = new CarbonAttributes
                    {
                        Country = "us",
                        State = "fl",
                        ElectricityUnit = "mwh",
                        ElectricityValue = 42.0m,
                        CarbonG = 16710476,
                        CarbonLb = 36840.29m,
                        CarbonKg = 16710.48m,
                        CarbonMt = 16.71m
                    }
                }
            };

            var httpResponse = new HttpResponseMessage(HttpStatusCode.Created)
            {
                Content = new StringContent(JsonConvert.SerializeObject(expectedResponse))
            };
            httpResponse.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpResponse);

            var httpClient = new HttpClient(handlerMock.Object);
            var carbonService = new CarbonService(httpClient, _configurationMock.Object, _loggerMock.Object);

            // Act
            var result = await carbonService.CalculateElectricityEmissionsAsync("mwh", 42.0m, "us", "fl");

            // Assert
            result.Should().BeEquivalentTo(expectedResponse);
        }

        [Fact]
        public async Task CalculateElectricityEmissionsAsync_ShouldThrowException_WhenApiResponseIsNotFound()
        {
            // Arrange
            var handlerMock = new Mock<HttpMessageHandler>();
            handlerMock.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound,
                    Content = new StringContent("{\"message\":\"Resource not found\"}"),
                });

            var httpClient = new HttpClient(handlerMock.Object);
            var carbonService = new CarbonService(httpClient, _configurationMock.Object, _loggerMock.Object);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() =>
                carbonService.CalculateElectricityEmissionsAsync("mwh", 42.0m, "us", "fl"));

            Assert.Contains("Erro na API externa", exception.Message);
        }
    }
}
