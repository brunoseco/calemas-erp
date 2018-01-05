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

            if (filters.QuantidadeDe.IsSent())
                queryFilter = queryFilter.Where(_ => _.Quantidade >= filters.QuantidadeDe);

            if (filters.QuantidadeAte.IsSent())
                queryFilter = queryFilter.Where(_ => _.Quantidade <= filters.QuantidadeAte);

            return queryFilter;
        }

		public static IQueryable<EstoqueMovimentacao> WithLimitSubscriber(this IQueryable<EstoqueMovimentacao> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

