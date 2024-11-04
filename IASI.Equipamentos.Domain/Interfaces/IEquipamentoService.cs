using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Dtos;

namespace IASI.Equipamentos.Domain.Interfaces
{
    public interface IEquipamentoService
    {
        Task<IEnumerable<EquipamentoDTO>> ObterTodosAsync();
        Task<EquipamentoDTO> ObterPorIdAsync(int id);
        Task<bool> AdicionarAsync(EquipamentoDTO equipamento);
        Task<bool> AtualizarAsync(int id, EquipamentoDTO equipamento);
        Task<bool> RemoverAsync(int id);
    }
}
