using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;

namespace IASI.Equipamentos.Application.Services
{
    /// <summary>
    /// Serviço para gerenciamento de consumos.
    /// </summary>
    public class ConsumoService
    {
        private readonly IConsumoRepository _consumoRepository;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ConsumoService"/>.
        /// </summary>
        /// <param name="consumoRepository">O repositório de consumos.</param>
        public ConsumoService(IConsumoRepository consumoRepository)
        {
            _consumoRepository = consumoRepository;
        }

        /// <summary>
        /// Obtém todos os consumos.
        /// </summary>
        /// <returns>Uma lista de todos os consumos.</returns>
        public async Task<IEnumerable<Consumo>> ObterTodosAsync()
        {
            return await _consumoRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém um consumo por ID.
        /// </summary>
        /// <param name="id">O ID do consumo.</param>
        /// <returns>O consumo correspondente ao ID fornecido.</returns>
        public async Task<Consumo> ObterPorIdAsync(int id)
        {
            return await _consumoRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Adiciona um novo consumo.
        /// </summary>
        /// <param name="consumo">O consumo a ser adicionado.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AdicionarAsync(Consumo consumo)
        {
            await _consumoRepository.AddAsync(consumo);
        }

        /// <summary>
        /// Atualiza um consumo existente.
        /// </summary>
        /// <param name="consumo">O consumo a ser atualizado.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AtualizarAsync(Consumo consumo)
        {
            await _consumoRepository.UpdateAsync(consumo);
        }

        /// <summary>
        /// Remove um consumo pelo ID.
        /// </summary>
        /// <param name="id">O ID do consumo a ser removido.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task RemoverAsync(int id)
        {
            await _consumoRepository.DeleteAsync(id);
        }
    }
}
