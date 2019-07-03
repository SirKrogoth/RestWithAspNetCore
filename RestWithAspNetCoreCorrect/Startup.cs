using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithAspNetCore.Model.Context;
using RestWithAspNetCore.Business;
using RestWithAspNetCore.Business.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using RestWithAspNetCoreCorrect.Repository.Generic;
using RestWithAspNetCoreCorrect.Business;
using RestWithAspNetCoreCorrect.Business.Implementations;
using Microsoft.Net.Http.Headers;
using Tapioca.HATEOAS;
using RestWithAspNetCoreCorrect.HyperMedia;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Rewrite;
using RestWithAspNetCoreCorrect.Security.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using RestWithAspNetCoreCorrect.Repository;
using RestWithAspNetCoreCorrect.Repository.Implementations;

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

            //Executando o Migrations
            ExecuteMigrations(connectionString);

            // ***Início do código de autenticação - Start authentication Code ***
            AutenticacaoDeUsuario(services);

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("json/xml"));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddXmlSerializerFormatters();

            //HEATOAS
            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            services.AddSingleton(filterOptions);

            //SWAGGER
            services.AddSwaggerGen(c =>
            {
                //v1 é a versão utilizada
                c.SwaggerDoc("v1",
                    new Info
                    {
                        Title = "Restfull API With ASP.NET Core 2" +
                        "v1"
                    });
            });

            //Serviço de versionamento
            services.AddApiVersioning();

            //Aqui estamos tratando a injeção de dependencias / Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImp>();
            services.AddScoped<IBookBusiness, BookBusinessImp>();
            services.AddScoped<ILoginBusiness, LoginBusinessImp>();
            services.AddScoped<IUserRepository, UserRepositoryImp>();
            //Injeção de dependencia do nosso generics
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        private void AutenticacaoDeUsuario(IServiceCollection services)
        {
            var signingConfigurations = new SigningConfiguration();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfiguration();

            //Aqui irá buscar configurações do appsettings.json
            new ConfigureFromConfigurationOptions<TokenConfiguration>(
                _configuration.GetSection("TokenConfigurations")
            )
            .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;
                paramsValidation.IssuerSigningKey = signingConfigurations.key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Validates the signing of a received token
                paramsValidation.ValidateIssuerSigningKey = true;

                // Checks if a received token is still valid
                paramsValidation.ValidateLifetime = true;

                // Tolerance time for the expiration of a token (used in case
                // of time synchronization problems between different
                // computers involved in the communication process)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });

            // Enables the use of the token as a means of
            // authorizing access to this project's resources
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });

            // *** Fim do código de Autenticação - End Authentication Code ***
        }

        private void ExecuteMigrations(string connectionString)
        {
            if (_environment.IsDevelopment())
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
                       
            //Abrindo swagger como página inicial
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API v1");
            });

            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseHttpsRedirection();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=values}/{id?}");
            });
        }
    }
}