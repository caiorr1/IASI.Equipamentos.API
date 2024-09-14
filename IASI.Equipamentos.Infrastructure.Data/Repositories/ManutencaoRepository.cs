using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IASI.Equipamentos.Domain.Entities;
using IASI.Equipamentos.Domain.Interfaces;
using IASI.Equipamentos.Infrastructure.Data;

namespace IASI.Equipamentos.Infrastructure.Data.Repositories
{
    public class ManutencaoRepository : IManutencaoRepository
    {
        private readonly AppDbContext _context;

        public ManutencaoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Manutencao>> GetAllAsync()
        {
            return await _context.Manutencoes.ToListAsync();
        }

        public async Task<Manutencao> GetByIdAsync(int id)
        {
            return await _context.Manutencoes.FindAsync(id);
        }

        public async Task AddAsync(Manutencao manutencao)
        {
            await _context.Manutencoes.AddAsync(manutencao);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Manutencao manutencao)
        {
            _context.Manutencoes.Update(manutencao);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var manutencao = await _context.Manutencoes.FindAsync(id);
            if (manutencao != null)
            {
                _context.Manutencoes.Remove(manutencao);
                await _context.SaveChangesAsync();
            }
        }
    }
}
