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
            var cnsCalemas = Configuration.GetSection("EFCoreConnStrings:Calemas").Value;

            services.AddDbContext<DbContextCore>(options => options.UseSqlServer(cnsCalemas));

            services.AddIdentityServer()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddSigningCredential(GetRSAParameters());

            services.AddScoped<CurrentUser>();
            services.AddTransient<IColaboradorRepository, ColaboradorRepository>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));
            services.AddSingleton<IConfiguration>(Configuration);

            Cors.Enable(services);

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, IOptions<ConfigSettingsBase> configSettingsBase)
        {
            loggerFactory.AddConsole(LogLevel.Debug);
            app.UseDeveloperExceptionPage();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/calemas-sso-server-api-{Date}.log");

            app.UseCors("AllowAnyOrigin");

            app.UseIdentityServer();

            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }

        private X509Certificate2 GetRSAParameters()
        {
            var pass = "Admin321$";
            return new X509Certificate2(Path.Combine(_env.ContentRootPath, "pfx", "calemas-certificate.pfx"), pass, X509KeyStorageFlags.Exportable);
        }
    }
}
