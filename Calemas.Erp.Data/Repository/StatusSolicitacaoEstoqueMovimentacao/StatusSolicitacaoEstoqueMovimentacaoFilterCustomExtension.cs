using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusSolicitacaoEstoqueMovimentacaoFilterCustomExtension
    {

        public static IQueryable<StatusSolicitacaoEstoqueMovimentacao> WithCustomFilters(this IQueryable<StatusSolicitacaoEstoqueMovimentacao> queryBase, StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<StatusSolicitacaoEstoqueMovimentacao> WithLimitTenant(this IQueryable<StatusSolicitacaoEstoqueMovimentacao> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

