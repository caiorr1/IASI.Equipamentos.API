using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;
using IASI.Equipamentos.Infrastructure.Data;

namespace IASI.Equipamentos.Infrastructure.Data.Repositories
{
    public class ConsumoRepository : IConsumoRepository
    {
        private readonly AppDbContext _context;

        public ConsumoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Consumo>> GetAllAsync()
        {
            return await _context.Consumos.ToListAsync();
        }

        public async Task<Consumo> GetByIdAsync(int id)
        {
            return await _context.Consumos.FindAsync(id);
        }

        public async Task AddAsync(Consumo consumo)
        {
            await _context.Consumos.AddAsync(consumo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Consumo consumo)
        {
            _context.Consumos.Update(consumo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var consumo = await _context.Consumos.FindAsync(id);
            if (consumo != null)
            {
                _context.Consumos.Remove(consumo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
