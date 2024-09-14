using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;

namespace IASI.Equipamentos.Application.Services
{
    /// <summary>
    /// Serviço para gerenciamento de manutenção.
    /// </summary>
    public class ManutencaoService
    {
        private readonly IManutencaoRepository _manutencaoRepository;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="ManutencaoService"/>.
        /// </summary>
        /// <param name="manutencaoRepository">O repositório de manutenção.</param>
        public ManutencaoService(IManutencaoRepository manutencaoRepository)
        {
            _manutencaoRepository = manutencaoRepository;
        }

        /// <summary>
        /// Obtém todas as manutenções.
        /// </summary>
        /// <returns>Uma lista de todas as manutenções.</returns>
        public async Task<IEnumerable<Manutencao>> ObterTodasAsync()
        {
            return await _manutencaoRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém uma manutenção por ID.
        /// </summary>
        /// <param name="id">O ID da manutenção.</param>
        /// <returns>A manutenção correspondente ao ID fornecido.</returns>
        public async Task<Manutencao> ObterPorIdAsync(int id)
        {
            return await _manutencaoRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Adiciona uma nova manutenção.
        /// </summary>
        /// <param name="manutencao">A manutenção a ser adicionada.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AdicionarAsync(Manutencao manutencao)
        {
            await _manutencaoRepository.AddAsync(manutencao);
        }

        /// <summary>
        /// Atualiza uma manutenção existente.
        /// </summary>
        /// <param name="manutencao">A manutenção a ser atualizada.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AtualizarAsync(Manutencao manutencao)
        {
            await _manutencaoRepository.UpdateAsync(manutencao);
        }

        /// <summary>
        /// Remove uma manutenção pelo ID.
        /// </summary>
        /// <param name="id">O ID da manutenção a ser removida.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task RemoverAsync(int id)
        {
            await _manutencaoRepository.DeleteAsync(id);
        }
    }
}
