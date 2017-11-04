using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class SolicitacaoEstoqueOrderCustomExtension
    {

        public static IQueryable<SolicitacaoEstoque> OrderByDomain(this IQueryable<SolicitacaoEstoque> queryBase, SolicitacaoEstoqueFilter filters)
        {
            return queryBase.OrderBy(_ => _.SolicitacaoEstoqueId);
        }

    }
}

