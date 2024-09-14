using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;

namespace IASI.Equipamentos.Application.Services
{
    /// <summary>
    /// Serviço para gerenciamento de resíduos.
    /// </summary>
    public class ResiduoService
    {
        private readonly IResiduoRepository _residuoRepository;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ResiduoService"/>.
        /// </summary>
        /// <param name="residuoRepository">O repositório de resíduos.</param>
        public ResiduoService(IResiduoRepository residuoRepository)
        {
            _residuoRepository = residuoRepository;
        }

        /// <summary>
        /// Obtém todos os resíduos.
        /// </summary>
        /// <returns>Uma lista de todos os resíduos.</returns>
        public async Task<IEnumerable<Residuo>> ObterTodosAsync()
        {
            return await _residuoRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém um resíduo por ID.
        /// </summary>
        /// <param name="id">O ID do resíduo.</param>
        /// <returns>O resíduo correspondente ao ID fornecido.</returns>
        public async Task<Residuo> ObterPorIdAsync(int id)
        {
            return await _residuoRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Adiciona um novo resíduo.
        /// </summary>
        /// <param name="residuo">O resíduo a ser adicionado.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AdicionarAsync(Residuo residuo)
        {
            await _residuoRepository.AddAsync(residuo);
        }

        /// <summary>
        /// Atualiza um resíduo existente.
        /// </summary>
        /// <param name="residuo">O resíduo a ser atualizado.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AtualizarAsync(Residuo residuo)
        {
            await _residuoRepository.UpdateAsync(residuo);
        }

        /// <summary>
        /// Remove um resíduo pelo ID.
        /// </summary>
        /// <param name="id">O ID do resíduo a ser removido.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task RemoverAsync(int id)
        {
            await _residuoRepository.DeleteAsync(id);
        }
    }
}
