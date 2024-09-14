using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.Domain.Interfaces
{
    public interface IManutencaoRepository
    {
        Task<IEnumerable<Manutencao>> GetAllAsync();
        Task<Manutencao> GetByIdAsync(int id);
        Task AddAsync(Manutencao manutencao);
        Task UpdateAsync(Manutencao manutencao);
        Task DeleteAsync(int id);
    }
}
