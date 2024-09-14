using Microsoft.EntityFrameworkCore;
using IASI.Equipamentos.Domain.Entities;

namespace IASI.Equipamentos.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Equipamento> Equipamentos { get; set; }
        public DbSet<Previsao> Previsoes { get; set; }
        public DbSet<Consumo> Consumos { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<Residuo> Residuos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipamento>().ToTable("tb_iasi_equipamentos_equipamento");
            modelBuilder.Entity<Previsao>().ToTable("tb_iasi_equipamentos_previsao");
            modelBuilder.Entity<Consumo>().ToTable("tb_iasi_equipamentos_consumo");
            modelBuilder.Entity<Manutencao>().ToTable("tb_iasi_equipamentos_manutencao");
            modelBuilder.Entity<Residuo>().ToTable("tb_iasi_equipamentos_residuo");
        }
    }
}
