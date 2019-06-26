using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithAspNetCore.Model.Context;
using RestWithAspNetCore.Business;
using RestWithAspNetCore.Business.Implementations;
using Microsoft.EntityFrameworkCore;
using RestWithAspNetCore.Repository.Implementations;
using RestWithAspNetCore.Repository;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace RestWithAspNetCore
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        //Método Construtor
        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MysqlConnection:MysqlConnectionString"];

            services.AddDbContext<MysqlContext>(options => options.UseMySql(connectionString));

            if(_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {                        
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();
                }
                catch (System.Exception ex)
                {
                    _logger.LogCritical("Database Migrations failed. ", ex);
                    throw;
                }
            }            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Serviço de versionamento
            services.AddApiVersioning();

            //Aqui estamos tratando a injeção de dependencias / Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImp>();
            services.AddScoped<IPersonRepository, PersonRepositoryImp>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                loggerFactory.AddConsole(_configuration.GetSection("Logging"));
                loggerFactory.AddDebug();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}