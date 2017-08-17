using Common.API;
using Common.Domain.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Calemas.Erp.Application.Config;
using Calemas.Erp.Data.Context;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Common.API.Extensions;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Converters;
using Common.API.Converters;

namespace Calemas.Erp.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                 .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                 .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                 .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DbContextCore>(options => options.UseSqlServer(Configuration.GetSection("EFCoreConnStrings:Core").Value));

            services.AddDistributedRedisCache(options =>
            {
                options.Configuration = Configuration.GetSection("RedisConnStrings:Core").Value;
                options.InstanceName = "Core";
            });

            services.Configure<ConfigSettingsBase>(Configuration.GetSection("ConfigSettings"));
            services.AddSingleton<IConfiguration>(Configuration);

            Cors.Enable(services);
            ConfigContainerCore.Config(services);

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.Converters.Add(new DateTimeConverter());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<ConfigSettingsBase> configSettingsBase)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile("Logs/calemas-api-{Date}.log");

            app.UseDeveloperExceptionPage();

            app.UseIdentityServerAuthentication(new IdentityServerAuthenticationOptions
            {
                Authority = configSettingsBase.Value.AuthorityEndPoint,
                ApiName = "ssocalemas",
                RequireHttpsMetadata = false
            });

            //var suportedCultures = new[]
            //{
            //    new CultureInfo("pt-BR")
            //};

            //app.UseRequestLocalization(new RequestLocalizationOptions
            //{
            //    DefaultRequestCulture = new RequestCulture("pt-BR"),
            //    SupportedCultures = suportedCultures,
            //    SupportedUICultures = suportedCultures
            //});

            app.AddTokenMiddleware();
            app.UseMvc();

            AutoMapperConfigCore.RegisterMappings();
        }
    }

}
