using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using IASI.Equipamentos.Infrastructure.Data;
using IASI.Equipamentos.Domain.Interfaces;
using IASI.Equipamentos.Infrastructure.Data.Repositories;
using IASI.Equipamentos.Application.Services;

namespace IASI.Equipamentos.Infrastructure.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services, string connectionString)
        {
            // Registrar o contexto do banco de dados
            services.AddDbContext<AppDbContext>(options =>
                options.UseOracle(connectionString));

            // Registrar os repositórios
            services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
            services.AddScoped<IPrevisaoRepository, PrevisaoRepository>();
            services.AddScoped<IConsumoRepository, ConsumoRepository>();
            services.AddScoped<IManutencaoRepository, ManutencaoRepository>();
            services.AddScoped<IResiduoRepository, ResiduoRepository>();

            // Registrar os serviços
            services.AddScoped<EquipamentoService>();
            services.AddScoped<PrevisaoService>();
            services.AddScoped<ConsumoService>();
            services.AddScoped<ManutencaoService>();
            services.AddScoped<ResiduoService>();

            return services;
        }
    }
}
