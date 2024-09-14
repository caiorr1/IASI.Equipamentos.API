using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Application.Services;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.API.Controllers
{
    /// <summary>
    /// Controlador para gerenciamento de manutenção.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ManutencaoController : ControllerBase
    {
        private readonly ManutencaoService _manutencaoService;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ManutencaoController"/>.
        /// </summary>
        /// <param name="manutencaoService">O serviço de manutenção.</param>
        public ManutencaoController(ManutencaoService manutencaoService)
        {
            _manutencaoService = manutencaoService;
        }

        /// <summary>
        /// Obtém todas as manutenções.
        /// </summary>
        /// <returns>Uma lista de todas as manutenções.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Manutencao>>> GetAll()
        {
            var manutencoes = await _manutencaoService.ObterTodasAsync();
            return Ok(manutencoes);
        }

        /// <summary>
        /// Obtém uma manutenção por ID.
        /// </summary>
        /// <param name="id">O ID da manutenção.</param>
        /// <returns>A manutenção correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Manutencao>> GetById(int id)
        {
            var manutencao = await _manutencaoService.ObterPorIdAsync(id);
            if (manutencao == null)
            {
                return NotFound();
            }
            return Ok(manutencao);
        }

        /// <summary>
        /// Cria uma nova manutenção.
        /// </summary>
        /// <param name="manutencao">A manutenção a ser criada.</param>
        /// <returns>O resultado da operação de criação.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Manutencao manutencao)
        {
            await _manutencaoService.AdicionarAsync(manutencao);
            return CreatedAtAction(nameof(GetById), new { id = manutencao.Id }, manutencao);
        }

        /// <summary>
        /// Atualiza uma manutenção existente.
        /// </summary>
        /// <param name="id">O ID da manutenção a ser atualizada.</param>
        /// <param name="manutencao">Os dados da manutenção a serem atualizados.</param>
        /// <returns>O resultado da operação de atualização.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Manutencao manutencao)
        {
            if (id != manutencao.Id)
            {
                return BadRequest();
            }

            await _manutencaoService.AtualizarAsync(manutencao);
            return NoContent();
        }

        /// <summary>
        /// Remove uma manutenção pelo ID.
        /// </summary>
        /// <param name="id">O ID da manutenção a ser removida.</param>
        /// <returns>O resultado da operação de remoção.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _manutencaoService.RemoverAsync(id);
            return NoContent();
        }
    }
}
