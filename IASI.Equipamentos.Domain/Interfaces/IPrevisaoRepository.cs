using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.Domain.Interfaces
{
    public interface IPrevisaoRepository
    {
        Task<IEnumerable<Previsao>> GetAllAsync();
        Task<Previsao> GetByIdAsync(int id);
        Task AddAsync(Previsao previsao);
        Task UpdateAsync(Previsao previsao);
        Task DeleteAsync(int id);
    }
}
