using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class OrdemServicoInteracaoFilterCustomExtension
    {

        public static IQueryable<OrdemServicoInteracao> WithCustomFilters(this IQueryable<OrdemServicoInteracao> queryBase, OrdemServicoInteracaoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<OrdemServicoInteracao> WithLimitTenant(this IQueryable<OrdemServicoInteracao> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

