using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IASI.Equipamentos.Application.Services;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using IASI.Equipamentos.Domain.Dtos;
using Newtonsoft.Json;

namespace IASI.Equipamentos.API.Controllers
{
    /// <summary>
    /// Controlador para cálculo de emissões de carbono.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CarbonController : ControllerBase
    {
        private readonly CarbonService _carbonService;
        private readonly ILogger<CarbonController> _logger;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="CarbonController"/>.
        /// </summary>
        /// <param name="carbonService">O serviço de cálculo de emissões de carbono.</param>
        /// <param name="logger">O logger para registrar informações e erros.</param>
        public CarbonController(CarbonService carbonService, ILogger<CarbonController> logger)
        {
            _carbonService = carbonService;
            _logger = logger;
        }

        /// <summary>
        /// Calcula as emissões de carbono baseadas no consumo de eletricidade.
        /// </summary>
        /// <param name="electricityUnit">Unidade de medida da eletricidade (ex: "mwh", "kwh").</param>
        /// <param name="electricityValue">Quantidade de eletricidade consumida.</param>
        /// <param name="country">Código do país onde a eletricidade foi consumida.</param>
        /// <param name="state">Estado ou região onde a eletricidade foi consumida (opcional).</param>
        /// <returns>Um objeto contendo a estimativa de emissões de carbono.</returns>
        /// <response code="200">Retorna a estimativa de emissões de carbono.</response>
        /// <response code="500">Erro interno do servidor.</response>
        [HttpPost("calculate-electricity-emissions")]
        public async Task<ActionResult<CarbonEstimateResponse>> CalculateElectricityEmissions(string electricityUnit, decimal electricityValue, string country, string state = null)
        {
            try
            {
                var result = await _carbonService.CalculateElectricityEmissionsAsync(electricityUnit, electricityValue, country, state);
                _logger.LogInformation("Resultado do serviço CarbonService: {Result}", JsonConvert.SerializeObject(result));
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao calcular as emissões de eletricidade");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
