using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class MotivoEstoqueMovimentacaoOrderCustomExtension
    {

        public static IQueryable<MotivoEstoqueMovimentacao> OrderByDomain(this IQueryable<MotivoEstoqueMovimentacao> queryBase, MotivoEstoqueMovimentacaoFilter filters)
        {
            return queryBase.OrderBy(_ => _.MotivoEstoqueMovimentacaoId);
        }

    }
}

