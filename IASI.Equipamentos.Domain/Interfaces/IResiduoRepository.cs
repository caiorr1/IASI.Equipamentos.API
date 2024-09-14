using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.Domain.Interfaces
{
    public interface IResiduoRepository
    {
        Task<IEnumerable<Residuo>> GetAllAsync();
        Task<Residuo> GetByIdAsync(int id);
        Task AddAsync(Residuo residuo);
        Task UpdateAsync(Residuo residuo);
        Task DeleteAsync(int id);
    }
}
