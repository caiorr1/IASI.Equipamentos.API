using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Application.Services;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.API.Controllers
{
    /// <summary>
    /// Controlador para gerenciamento de consumo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ConsumoController : ControllerBase
    {
        private readonly ConsumoService _consumoService;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ConsumoController"/>.
        /// </summary>
        /// <param name="consumoService">O serviço de consumo.</param>
        public ConsumoController(ConsumoService consumoService)
        {
            _consumoService = consumoService;
        }

        /// <summary>
        /// Obtém todos os consumos.
        /// </summary>
        /// <returns>Uma lista de todos os consumos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Consumo>>> GetAll()
        {
            var consumos = await _consumoService.ObterTodosAsync();
            return Ok(consumos);
        }

        /// <summary>
        /// Obtém um consumo por ID.
        /// </summary>
        /// <param name="id">O ID do consumo.</param>
        /// <returns>O consumo correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Consumo>> GetById(int id)
        {
            var consumo = await _consumoService.ObterPorIdAsync(id);
            if (consumo == null)
            {
                return NotFound();
            }
            return Ok(consumo);
        }

        /// <summary>
        /// Cria um novo consumo.
        /// </summary>
        /// <param name="consumo">O consumo a ser criado.</param>
        /// <returns>O resultado da operação de criação.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Consumo consumo)
        {
            await _consumoService.AdicionarAsync(consumo);
            return CreatedAtAction(nameof(GetById), new { id = consumo.Id }, consumo);
        }

        /// <summary>
        /// Atualiza um consumo existente.
        /// </summary>
        /// <param name="id">O ID do consumo a ser atualizado.</param>
        /// <param name="consumo">Os dados do consumo a serem atualizados.</param>
        /// <returns>O resultado da operação de atualização.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Consumo consumo)
        {
            if (id != consumo.Id)
            {
                return BadRequest();
            }

            await _consumoService.AtualizarAsync(consumo);
            return NoContent();
        }

        /// <summary>
        /// Remove um consumo pelo ID.
        /// </summary>
        /// <param name="id">O ID do consumo a ser removido.</param>
        /// <returns>O resultado da operação de remoção.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _consumoService.RemoverAsync(id);
            return NoContent();
        }
    }
}
