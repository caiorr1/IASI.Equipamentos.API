using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Interfaces;
using IASI.Equipamentos.Domain.Dtos;

namespace IASI.Equipamentos.API.Controllers
{
    /// <summary>
    /// Controlador para gerenciamento de equipamentos.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EquipamentoController : ControllerBase
    {
        private readonly IEquipamentoService _equipamentoService;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="EquipamentoController"/>.
        /// </summary>
        /// <param name="equipamentoService">O serviço de equipamentos.</param>
        public EquipamentoController(IEquipamentoService equipamentoService)
        {
            _equipamentoService = equipamentoService;
        }

        /// <summary>
        /// Obtém todos os equipamentos.
        /// </summary>
        /// <returns>Uma lista de todos os equipamentos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EquipamentoDTO>>> GetAll()
        {
            var equipamentos = await _equipamentoService.ObterTodosAsync();
            return Ok(equipamentos);
        }

        /// <summary>
        /// Obtém um equipamento por ID.
        /// </summary>
        /// <param name="id">O ID do equipamento.</param>
        /// <returns>O equipamento correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<EquipamentoDTO>> GetById(int id)
        {
            var equipamento = await _equipamentoService.ObterPorIdAsync(id);
            if (equipamento == null)
            {
                return NotFound();
            }
            return Ok(equipamento);
        }

        /// <summary>
        /// Cria um novo equipamento.
        /// </summary>
        /// <param name="equipamento">O equipamento a ser criado.</param>
        /// <returns>O resultado da operação de criação.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(EquipamentoDTO equipamento)
        {
            await _equipamentoService.AdicionarAsync(equipamento);
            return CreatedAtAction(nameof(GetById), new { id = equipamento.Id }, equipamento);
        }

        /// <summary>
        /// Atualiza um equipamento existente.
        /// </summary>
        /// <param name="id">O ID do equipamento a ser atualizado.</param>
        /// <param name="equipamento">Os dados do equipamento a serem atualizados.</param>
        /// <returns>O resultado da operação de atualização.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EquipamentoDTO equipamento)
        {
            if (id != equipamento.Id)
            {
                return BadRequest();
            }

            var success = await _equipamentoService.AtualizarAsync(id, equipamento);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Remove um equipamento pelo ID.
        /// </summary>
        /// <param name="id">O ID do equipamento a ser removido.</param>
        /// <returns>O resultado da operação de remoção.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _equipamentoService.RemoverAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
