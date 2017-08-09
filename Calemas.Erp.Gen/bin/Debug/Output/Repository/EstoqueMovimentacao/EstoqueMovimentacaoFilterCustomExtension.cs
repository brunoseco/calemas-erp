using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EstoqueMovimentacaoFilterCustomExtension
    {

        public static IQueryable<EstoqueMovimentacao> WithCustomFilters(this IQueryable<EstoqueMovimentacao> queryBase, EstoqueMovimentacaoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<EstoqueMovimentacao> WithLimitTenant(this IQueryable<EstoqueMovimentacao> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

