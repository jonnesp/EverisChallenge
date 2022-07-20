using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Notificacoes;
using EverisChallenge.Data.Contexto;
using EverisChallenge.Data.Repository;
using EverisChallenge.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EverisChallenge.App.Extensions
{
    public static class DependencyConfigure
    {
        public static IServiceCollection ConfigureSqlDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<AdviceService, RefitCustomerService>();
            services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
