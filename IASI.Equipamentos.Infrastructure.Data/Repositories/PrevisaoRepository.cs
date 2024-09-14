using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;
using IASI.Equipamentos.Infrastructure.Data;

namespace IASI.Equipamentos.Infrastructure.Data.Repositories
{
    public class PrevisaoRepository : IPrevisaoRepository
    {
        private readonly AppDbContext _context;

        public PrevisaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Previsao>> GetAllAsync()
        {
            return await _context.Previsoes.ToListAsync();
        }

        public async Task<Previsao> GetByIdAsync(int id)
        {
            return await _context.Previsoes.FindAsync(id);
        }

        public async Task AddAsync(Previsao previsao)
        {
            await _context.Previsoes.AddAsync(previsao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Previsao previsao)
        {
            _context.Previsoes.Update(previsao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var previsao = await _context.Previsoes.FindAsync(id);
            if (previsao != null)
            {
                _context.Previsoes.Remove(previsao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
