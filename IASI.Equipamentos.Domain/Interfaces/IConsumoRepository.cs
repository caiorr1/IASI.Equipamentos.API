using System.Collections.Generic;
using System.Threading.Tasks;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.Domain.Interfaces
{
    public interface IConsumoRepository
    {
        Task<IEnumerable<Consumo>> GetAllAsync();
        Task<Consumo> GetByIdAsync(int id);
        Task AddAsync(Consumo consumo);
        Task UpdateAsync(Consumo consumo);
        Task DeleteAsync(int id);
    }
}
