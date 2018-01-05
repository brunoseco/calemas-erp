using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusPagamentoFilterCustomExtension
    {

        public static IQueryable<StatusPagamento> WithCustomFilters(this IQueryable<StatusPagamento> queryBase, StatusPagamentoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusPagamento> WithLimitTenant(this IQueryable<StatusPagamento> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

