using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Application.Services;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.API.Controllers
{
    /// <summary>
    /// Controlador para gerenciamento de resíduo.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ResiduoController : ControllerBase
    {
        private readonly ResiduoService _residuoService;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ResiduoController"/>.
        /// </summary>
        /// <param name="residuoService">O serviço de resíduo.</param>
        public ResiduoController(ResiduoService residuoService)
        {
            _residuoService = residuoService;
        }

        /// <summary>
        /// Obtém todos os resíduos.
        /// </summary>
        /// <returns>Uma lista de todos os resíduos.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Residuo>>> GetAll()
        {
            var residuos = await _residuoService.ObterTodosAsync();
            return Ok(residuos);
        }

        /// <summary>
        /// Obtém um resíduo por ID.
        /// </summary>
        /// <param name="id">O ID do resíduo.</param>
        /// <returns>O resíduo correspondente ao ID fornecido.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Residuo>> GetById(int id)
        {
            var residuo = await _residuoService.ObterPorIdAsync(id);
            if (residuo == null)
            {
                return NotFound();
            }
            return Ok(residuo);
        }

        /// <summary>
        /// Cria um novo resíduo.
        /// </summary>
        /// <param name="residuo">O resíduo a ser criado.</param>
        /// <returns>O resultado da operação de criação.</returns>
        [HttpPost]
        public async Task<IActionResult> Create(Residuo residuo)
        {
            await _residuoService.AdicionarAsync(residuo);
            return CreatedAtAction(nameof(GetById), new { id = residuo.Id }, residuo);
        }

        /// <summary>
        /// Atualiza um resíduo existente.
        /// </summary>
        /// <param name="id">O ID do resíduo a ser atualizado.</param>
        /// <param name="residuo">Os dados do resíduo a serem atualizados.</param>
        /// <returns>O resultado da operação de atualização.</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Residuo residuo)
        {
            if (id != residuo.Id)
            {
                return BadRequest();
            }

            await _residuoService.AtualizarAsync(residuo);
            return NoContent();
        }

        /// <summary>
        /// Remove um resíduo pelo ID.
        /// </summary>
        /// <param name="id">O ID do resíduo a ser removido.</param>
        /// <returns>O resultado da operação de remoção.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _residuoService.RemoverAsync(id);
            return NoContent();
        }
    }
}
