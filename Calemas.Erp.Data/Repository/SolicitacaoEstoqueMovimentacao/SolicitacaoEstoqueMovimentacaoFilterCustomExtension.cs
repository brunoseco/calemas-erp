using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class SolicitacaoEstoqueMovimentacaoFilterCustomExtension
    {

        public static IQueryable<SolicitacaoEstoqueMovimentacao> WithCustomFilters(this IQueryable<SolicitacaoEstoqueMovimentacao> queryBase, SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<SolicitacaoEstoqueMovimentacao> WithLimitTenant(this IQueryable<SolicitacaoEstoqueMovimentacao> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

