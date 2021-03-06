using AutoMapper;
using EverisChallenge.App.Extensions;
using EverisChallenge.App.Filtros;
using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using EverisChallenge.Business.Notificacoes;
using EverisChallenge.Data.Contexto;
using EverisChallenge.Data.Repository;
using EverisChallenge.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Refit;
using System;
using System.Text;

namespace EverisChallenge.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers(c =>
            {
                c.Filters.Add<MyExceptionFilter>();
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EverisChallenge.App", Version = "v1" });
            });

            services.AddAutoMapper(typeof(Startup));

            services.AddHttpContextAccessor();
            

            var appSettingsSection = Configuration.GetSection("AppSettings");
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

            services.AddScoped<INotificador, Notificador>();
            services.Configure<BookStoreDatabaseSettings>(Configuration.GetSection("BookStoreDatabase"));
            services.ConfigureSqlDependencies(Configuration);
            services.AddScoped<IBookDb, BookDb>();
            services.AddRefitClient<IAdvice>().ConfigureHttpClient(c => 
            {
                c.BaseAddress = new Uri(Configuration.GetSection("AdviceAddress").GetSection("AdviceBaseAddress").Value);
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EverisChallenge.App v1"));
            }

            app.UseAuthentication();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
