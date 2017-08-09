using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class UnidadeMedidaFilterCustomExtension
    {

        public static IQueryable<UnidadeMedida> WithCustomFilters(this IQueryable<UnidadeMedida> queryBase, UnidadeMedidaFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<UnidadeMedida> WithLimitTenant(this IQueryable<UnidadeMedida> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

