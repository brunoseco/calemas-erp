using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusOrdemServicoFilterCustomExtension
    {

        public static IQueryable<StatusOrdemServico> WithCustomFilters(this IQueryable<StatusOrdemServico> queryBase, StatusOrdemServicoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusOrdemServico> WithLimitTenant(this IQueryable<StatusOrdemServico> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

