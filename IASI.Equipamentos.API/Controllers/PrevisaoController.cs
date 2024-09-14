using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Application.Services;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.API.Controllers
{
    /// <summary>
    /// Controlador para gerenciamento de previsões.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class PrevisaoController : ControllerBase
    {
        private readonly PrevisaoService _previsaoService;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="PrevisaoController"/>.
        /// </summary>
        /// <param name="previsaoService">O serviço de previsão.</param>
        public PrevisaoController(PrevisaoService previsaoService)
        {
            _previsaoService = previsaoService;
        }

        /// <summary>
        /// Obtém todas as previsões.
        /// </summary>
        /// <returns>Uma lista de todas as previsões.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Previsao>>> GetAll()
        {
            var previsoes = await _previsaoService.ObterTodasAsync();
            return Ok(previsoes);
        }

        /// <summary>
        /// Obtém uma previsão por ID.
        /// </summary>
        /// <param name="id">O ID da previsão.</param>
        /// <returns>A previsão correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Previsao>> GetById(int id)
        {
            var previsao = await _previsaoService.ObterPorIdAsync(id);
            if (previsao == null)
            {
                return NotFound();
            }
            return Ok(previsao);
        }

        /// <summary>
        /// Cria uma nova previsão.
        /// </summary>
        /// <param name="previsao">A previsão a ser criada.</param>
        /// <returns>O resultado da operação de criação.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Previsao previsao)
        {
            await _previsaoService.AdicionarAsync(previsao);
            return CreatedAtAction(nameof(GetById), new { id = previsao.Id }, previsao);
        }

        /// <summary>
        /// Atualiza uma previsão existente.
        /// </summary>
        /// <param name="id">O ID da previsão a ser atualizada.</param>
        /// <param name="previsao">Os dados da previsão a serem atualizados.</param>
        /// <returns>O resultado da operação de atualização.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Previsao previsao)
        {
            if (id != previsao.Id)
            {
                return BadRequest();
            }

            await _previsaoService.AtualizarAsync(previsao);
            return NoContent();
        }

        /// <summary>
        /// Remove uma previsão pelo ID.
        /// </summary>
        /// <param name="id">O ID da previsão a ser removida.</param>
        /// <returns>O resultado da operação de remoção.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _previsaoService.RemoverAsync(id);
            return NoContent();
        }
    }
}
