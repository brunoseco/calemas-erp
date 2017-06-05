using Common.Cache;
using Common.Domain.Interfaces;
using Common.Orm;
using Microsoft.Extensions.DependencyInjection;
using Calemas.Erp.Application;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Data.Context;
using Calemas.Erp.Data.Repository;
using Calemas.Erp.Domain.Interfaces.Repository;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Calemas.Erp.Domain.Interfaces.Services;
using Calemas.Erp.Domain.Services;
using Common.Domain.Model;

namespace Calemas.Erp.Api
{
    public static partial class ConfigContainerCalemas.Erp 
    {

        public static void RegisterOtherComponents(IServiceCollection services)
        {
			services.AddScoped<CurrentUser>();
        }
    }
}
