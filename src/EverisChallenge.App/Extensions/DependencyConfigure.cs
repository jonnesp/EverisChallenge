using AutoMapper;
using EverisChallenge.App.DTOs;
using EverisChallenge.App.Filtros;
using EverisChallenge.App.HealthCheck;
using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using EverisChallenge.Business.Notificacoes;
using EverisChallenge.Data.Contexto;
using EverisChallenge.Data.Repository;
using EverisChallenge.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Refit;
using System;
using System.Text;

namespace EverisChallenge.App.Extensions
{
    public static class DependencyConfigure
    {
        public static IServiceCollection ConfigureAllDependencies(this IServiceCollection services, IConfiguration configuration)
        {
                services
                .ConfigureInterfaces(configuration)
                .ConfigureFilters()
                .ConfigureHealthCheck()
                .ConfigureJwt(configuration)
                .ConfigureRefit(configuration)
                .ConfigureDataBase(configuration);

            return services;
        }

        private static IServiceCollection ConfigureInterfaces(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<AdviceService, RefitCustomerService>();
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<IBookDb, BookDb>();
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }

        private static IServiceCollection ConfigureRefit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRefitClient<IAdvice>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(configuration.GetSection("AdviceAddress").GetSection("AdviceBaseAddress").Value);
            });
            return services;
        }

        private static IServiceCollection ConfigureFilters(this IServiceCollection services)
        {
            services.AddControllers(c =>
            {
                c.Filters.Add<MyExceptionFilter>();
            });

            return services;
        }

        private static IServiceCollection ConfigureDataBase(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<BookStoreDatabaseSettings>(configuration.GetSection("BookStoreDatabase"));
            return services;
        }

        private static IServiceCollection ConfigureHealthCheck(this IServiceCollection services)
        {
            services.AddHealthChecks().AddCheck<CustomHealthCheck>("HealthCheck Customizavel");
            services.AddHealthChecksUI(options =>
            {
                options.SetEvaluationTimeInSeconds(5);
                options.MaximumHistoryEntriesPerEndpoint(10);
                options.AddHealthCheckEndpoint("API com Health Checks", "/health");
            }).AddInMemoryStorage();

            return services;
        }

        private static IServiceCollection ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection("AppSettings");
            services.Configure<JwtConfig>(appSettingsSection);

            var jwtConfig = appSettingsSection.Get<JwtConfig>();


            var key = Encoding.ASCII.GetBytes(jwtConfig.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
