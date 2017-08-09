using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EstoqueMovimentacaoOrderCustomExtension
    {

        public static IQueryable<EstoqueMovimentacao> OrderByDomain(this IQueryable<EstoqueMovimentacao> queryBase, EstoqueMovimentacaoFilter filters)
        {
            return queryBase.OrderBy(_ => _.EstoqueMovimentacaoId);
        }

    }
}

