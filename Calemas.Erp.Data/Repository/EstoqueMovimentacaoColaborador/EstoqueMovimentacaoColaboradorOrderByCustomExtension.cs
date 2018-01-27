using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EstoqueMovimentacaoColaboradorOrderCustomExtension
    {

        public static IQueryable<EstoqueMovimentacaoColaborador> OrderByDomain(this IQueryable<EstoqueMovimentacaoColaborador> queryBase, EstoqueMovimentacaoColaboradorFilter filters)
        {
            return queryBase.OrderBy(_ => _.EstoqueMovimentacaoColaboradorId);
        }

    }
}

