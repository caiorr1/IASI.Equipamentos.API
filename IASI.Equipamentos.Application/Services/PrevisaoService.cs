using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;

namespace IASI.Equipamentos.Application.Services
{
    /// <summary>
    /// Serviço para gerenciamento de previsões.
    /// </summary>
    public class PrevisaoService
    {
        private readonly IPrevisaoRepository _previsaoRepository;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="PrevisaoService"/>.
        /// </summary>
        /// <param name="previsaoRepository">O repositório de previsões.</param>
        public PrevisaoService(IPrevisaoRepository previsaoRepository)
        {
            _previsaoRepository = previsaoRepository;
        }

        /// <summary>
        /// Obtém todas as previsões.
        /// </summary>
        /// <returns>Uma lista de todas as previsões.</returns>
        public async Task<IEnumerable<Previsao>> ObterTodasAsync()
        {
            return await _previsaoRepository.GetAllAsync();
        }

        /// <summary>
        /// Obtém uma previsão por ID.
        /// </summary>
        /// <param name="id">O ID da previsão.</param>
        /// <returns>A previsão correspondente ao ID fornecido.</returns>
        public async Task<Previsao> ObterPorIdAsync(int id)
        {
            return await _previsaoRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// Adiciona uma nova previsão.
        /// </summary>
        /// <param name="previsao">A previsão a ser adicionada.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AdicionarAsync(Previsao previsao)
        {
            await _previsaoRepository.AddAsync(previsao);
        }

        /// <summary>
        /// Atualiza uma previsão existente.
        /// </summary>
        /// <param name="previsao">A previsão a ser atualizada.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task AtualizarAsync(Previsao previsao)
        {
            await _previsaoRepository.UpdateAsync(previsao);
        }

        /// <summary>
        /// Remove uma previsão pelo ID.
        /// </summary>
        /// <param name="id">O ID da previsão a ser removida.</param>
        /// <returns>Uma tarefa representando a operação assíncrona.</returns>
        public async Task RemoverAsync(int id)
        {
            await _previsaoRepository.DeleteAsync(id);
        }
    }
}
