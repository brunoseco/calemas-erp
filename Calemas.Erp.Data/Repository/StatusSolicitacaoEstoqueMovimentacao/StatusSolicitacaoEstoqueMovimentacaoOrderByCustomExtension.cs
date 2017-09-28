using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusSolicitacaoEstoqueMovimentacaoOrderCustomExtension
    {

        public static IQueryable<StatusSolicitacaoEstoqueMovimentacao> OrderByDomain(this IQueryable<StatusSolicitacaoEstoqueMovimentacao> queryBase, StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusSolicitacaoEstoqueMovimentacaoId);
        }

    }
}

