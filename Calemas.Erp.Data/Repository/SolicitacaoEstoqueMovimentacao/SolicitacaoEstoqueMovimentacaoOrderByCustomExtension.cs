using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class SolicitacaoEstoqueMovimentacaoOrderCustomExtension
    {

        public static IQueryable<SolicitacaoEstoqueMovimentacao> OrderByDomain(this IQueryable<SolicitacaoEstoqueMovimentacao> queryBase, SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            return queryBase.OrderBy(_ => _.SolicitacaoEstoqueMovimentacaoId);
        }

    }
}

