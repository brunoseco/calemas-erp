using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EstoqueMovimentacaoColaboradorFilterCustomExtension
    {

        public static IQueryable<EstoqueMovimentacaoColaborador> WithCustomFilters(this IQueryable<EstoqueMovimentacaoColaborador> queryBase, EstoqueMovimentacaoColaboradorFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.EstoqueId.IsSent())
                queryFilter = queryFilter.Where(_ => _.EstoqueMovimentacao.EstoqueId == filters.EstoqueId);

            return queryFilter;
        }

		public static IQueryable<EstoqueMovimentacaoColaborador> WithLimitTenant(this IQueryable<EstoqueMovimentacaoColaborador> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

