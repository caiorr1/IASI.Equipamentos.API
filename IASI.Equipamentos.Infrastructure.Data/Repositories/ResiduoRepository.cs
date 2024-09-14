using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;
using IASI.Equipamentos.Infrastructure.Data;

namespace IASI.Equipamentos.Infrastructure.Data.Repositories
{
    public class ResiduoRepository : IResiduoRepository
    {
        private readonly AppDbContext _context;

        public ResiduoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Residuo>> GetAllAsync()
        {
            return await _context.Residuos.ToListAsync();
        }

        public async Task<Residuo> GetByIdAsync(int id)
        {
            return await _context.Residuos.FindAsync(id);
        }

        public async Task AddAsync(Residuo residuo)
        {
            await _context.Residuos.AddAsync(residuo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Residuo residuo)
        {
            _context.Residuos.Update(residuo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var residuo = await _context.Residuos.FindAsync(id);
            if (residuo != null)
            {
                _context.Residuos.Remove(residuo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
