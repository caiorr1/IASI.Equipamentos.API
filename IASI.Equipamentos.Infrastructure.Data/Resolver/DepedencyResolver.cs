using Microsoft.Extensions.DependencyInjection;
using IASI.Equipamentos.Application.Services;

namespace IASI.Equipamentos.Application.Resolver
{
    /// <summary>
    /// Classe para configurar a injeção de dependências dos serviços da aplicação.
    /// </summary>
    public static class DependencyResolver
    {
        /// <summary>
        /// Registra os serviços da aplicação para injeção de dependências.
        /// </summary>
        /// <param name="services">A coleção de serviços do aplicativo.</param>
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<EquipamentoService>();
            services.AddScoped<ConsumoService>();
            services.AddScoped<ManutencaoService>();
            services.AddScoped<PrevisaoService>();
            services.AddScoped<ResiduoService>();
        }
    }
}
