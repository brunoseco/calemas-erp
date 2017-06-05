using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Microsoft.Extensions.DependencyInjection;
using Calemas.Erp.Application;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Data.Context;
using Calemas.Erp.Data.Repository;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Domain.Services;

namespace Calemas.Erp.Api
{
    public static partial class ConfigContainerCalemas.Erp
    {

        public static void Config(IServiceCollection services)
        {
            services.AddScoped<ICache, RedisComponent>();
            services.AddScoped<IUnitOfWork, UnitOfWork<DbContextCalemas.Erp>>();
            
			services.AddScoped<IBancoApplicationService, BancoApplicationService>();
			services.AddScoped<IBancoService, BancoService>();
			services.AddScoped<IBancoRepository, BancoRepository>();



            RegisterOtherComponents(services);
        }
    }
}
