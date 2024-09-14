using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;
using IASI.Equipamentos.Infrastructure.Data;

namespace IASI.Equipamentos.Infrastructure.Data.Repositories
{
    public class EquipamentoRepository : IEquipamentoRepository
    {
        private readonly AppDbContext _context;

        public EquipamentoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Equipamento>> GetAllAsync()
        {
            return await _context.Equipamentos.ToListAsync();
        }

        public async Task<Equipamento> GetByIdAsync(int id)
        {
            return await _context.Equipamentos.FindAsync(id);
        }

        public async Task AddAsync(Equipamento equipamento)
        {
            await _context.Equipamentos.AddAsync(equipamento);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Equipamento equipamento)
        {
            _context.Equipamentos.Update(equipamento);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var equipamento = await _context.Equipamentos.FindAsync(id);
            if (equipamento != null)
            {
                _context.Equipamentos.Remove(equipamento);
                await _context.SaveChangesAsync();
            }
        }
    }
}
