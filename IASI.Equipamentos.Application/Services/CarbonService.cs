using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Dtos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IASI.Equipamentos.Application.Services
{
    public class CarbonService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CarbonService> _logger;
        private readonly string _apiKey;
        private readonly string _baseUrl;

        public CarbonService(HttpClient httpClient, IConfiguration configuration, ILogger<CarbonService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
            _apiKey = configuration["ExternalServices:CarbonInterfaceApi:ApiKey"];
            _baseUrl = configuration["ExternalServices:CarbonInterfaceApi:BaseUrl"];
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);
        }

        public async Task<CarbonEstimateResponse> CalculateElectricityEmissionsAsync(string electricityUnit, decimal electricityValue, string country, string state = null)
        {
            try
            {
                var requestBody = new
                {
                    type = "electricity",
                    electricity_unit = electricityUnit,
                    electricity_value = electricityValue,
                    country = country,
                    state = state
                };

                var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}estimates")
                {
                    Content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json")
                };

                _logger.LogInformation("Enviando requisição para API Carbon Interface: {Url}", request.RequestUri);

                var response = await _httpClient.SendAsync(request);

                _logger.LogInformation("Status da resposta: {StatusCode}", response.StatusCode);

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    _logger.LogError("Erro na API externa: {StatusCode} - {ErrorContent}", response.StatusCode, errorContent);
                    throw new Exception($"Erro na API externa: {response.StatusCode} - {errorContent}");
                }

                var content = await response.Content.ReadAsStringAsync();
                _logger.LogInformation("Conteúdo da resposta recebido da API Carbon Interface: {Content}", content);

                var carbonEstimateResponse = JsonConvert.DeserializeObject<CarbonEstimateResponse>(content);
                _logger.LogInformation("Resposta desserializada: {CarbonEstimateResponse}", JsonConvert.SerializeObject(carbonEstimateResponse));

                return carbonEstimateResponse;
            }
            catch (HttpRequestException e)
            {
                _logger.LogError(e, "Erro ao conectar com a API da Carbon Interface");
                throw new Exception("Erro ao conectar com a API da Carbon Interface", e);
            }
        }


    }
}
