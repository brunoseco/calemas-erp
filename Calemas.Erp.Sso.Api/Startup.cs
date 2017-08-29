using Common.API;
using Common.API.Extensions;
using Common.Domain.Base;
using Common.Domain.Model;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Calemas.Erp.Data.Context;
using Calemas.Erp.Data.Repository;
using Calemas.Erp.Domain.Interfaces.Repository;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Calemas.Erp.Sso.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
        private readonly IHostingEnvironment _env;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables();

            Configuration = builder.Build();
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var cnsSso = Configuration.GetSection("EFCoreConnStrings:Sso").Value;
            var cnsCalemas = Configuration.GetSection("EFCoreConnStrings:Calemas").Value;

            var migrationAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;
            services.AddDbContext<DbContextCore>(options => options.UseSqlServer(cnsCalemas));

            services.AddIdentityServer()
                .AddSigningCredential(GetRSAParameters())
                .AddConfigurationStore(builder => builder.UseSqlServer(cnsSso, options => options.MigrationsAssembly(migrationAssembly)))
                .AddOperationalStore(builder => builder.UseSqlServer(cnsSso, options => options.MigrationsAssembly(migrationAssembly)));

            services.AddScoped<CurrentUser>();
            services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));
            services.AddSingleton<IConfiguration>(Configuration);

            services.AddCors(options =>
            {
                options.AddPolicy("frontcore", policy =>
                {
                    policy.WithOrigins("http://localhost:8080")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
            services.AddCors(options =>
            {
                options.AddPolicy("frontprod", policy =>
                {
                    policy.WithOrigins("http://calemas.azurewebsites.net")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IOptions<ConfigSettingsBase> configSettingsBase)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            app.UseDeveloperExceptionPage();

            //InitializeDatabase(app);

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/calemas-sso-server-api-{Date}.log");

            app.UseCors("frontcore");
            app.UseCors("frontprod");

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        private void InitializeDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetRequiredService<PersistedGrantDbContext>().Database.Migrate();
                var context = serviceScope.ServiceProvider.GetRequiredService<ConfigurationDbContext>();
                context.Database.Migrate();
                if (!context.Clients.Any())
                {
                    foreach (var client in Config.GetClients())
                    {
                        context.Clients.Add(client.ToEntity());
                    }
                    context.SaveChanges();
                }
                if (!context.IdentityResources.Any())
                {
                    foreach (var identityResource in Config.GetIdentityResources())
                    {
                        context.IdentityResources.Add(identityResource.ToEntity());
                    }
                    context.SaveChanges();
                }
                if (!context.ApiResources.Any())
                {
                    foreach (var apiResource in Config.GetApiResources())
                    {
                        context.ApiResources.Add(apiResource.ToEntity());
                    }
                    context.SaveChanges();
                }
            }
        }

        private X509Certificate2 GetRSAParameters()
        {
            var pass = "Admin321$";
            return new X509Certificate2(Path.Combine(_env.ContentRootPath, "pfx", "calemas-certificate.pfx"), pass, X509KeyStorageFlags.Exportable);
        }
    }
}
