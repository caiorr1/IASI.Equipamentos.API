using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;

namespace IASI.Equipamentos.Application.Services
{
    /// <summary>
    /// Serviço para gerenciamento de equipamentos.
    /// </summary>
    public class EquipamentoService
    {
        private readonly IEquipamentoRepository _equipamentoRepository;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="EquipamentoService"/>.
        /// </summary>
        /// <param name="equipamentoRepository">O repositório de equipamentos.</param>
        public EquipamentoService(IEquipamentoRepository equipamentoRepository)
        {
            _equipamentoRepository = equipamentoRepository;
        }

        /// <summary>
        /// Obtém todos os equipamentos.
        /// </summary>
        /// <returns>Uma lista de todos os equipamentos.</returns>
        public async Task<IEnumerable<Equipamento>> ObterTodosAsync()
        {
            return await _equipamentoRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém um equipamento por ID.
        /// </summary>
        /// <param name="id">O ID do equipamento.</param>
        /// <returns>O equipamento correspondente ao ID fornecido.</returns>
        public async Task<Equipamento> ObterPorIdAsync(int id)
        {
            return await _equipamentoRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Adiciona um novo equipamento.
        /// </summary>
        /// <param name="equipamento">O equipamento a ser adicionado.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AdicionarAsync(Equipamento equipamento)
        {
            await _equipamentoRepository.AddAsync(equipamento);
        }

        /// <summary>
        /// Atualiza um equipamento existente.
        /// </summary>
        /// <param name="equipamento">O equipamento a ser atualizado.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AtualizarAsync(Equipamento equipamento)
        {
            await _equipamentoRepository.UpdateAsync(equipamento);
        }

        /// <summary>
        /// Remove um equipamento pelo ID.
        /// </summary>
        /// <param name="id">O ID do equipamento a ser removido.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task RemoverAsync(int id)
        {
            await _equipamentoRepository.DeleteAsync(id);
        }
    }
}
