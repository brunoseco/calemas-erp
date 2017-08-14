using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusClienteFilterCustomExtension
    {

        public static IQueryable<StatusCliente> WithCustomFilters(this IQueryable<StatusCliente> queryBase, StatusClienteFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusCliente> WithLimitTenant(this IQueryable<StatusCliente> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

