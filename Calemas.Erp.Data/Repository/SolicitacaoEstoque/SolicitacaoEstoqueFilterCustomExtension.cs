using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class SolicitacaoEstoqueFilterCustomExtension
    {

        public static IQueryable<SolicitacaoEstoque> WithCustomFilters(this IQueryable<SolicitacaoEstoque> queryBase, SolicitacaoEstoqueFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<SolicitacaoEstoque> WithLimitTenant(this IQueryable<SolicitacaoEstoque> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

