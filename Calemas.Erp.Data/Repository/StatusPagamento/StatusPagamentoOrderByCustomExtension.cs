using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusPagamentoOrderCustomExtension
    {

        public static IQueryable<StatusPagamento> OrderByDomain(this IQueryable<StatusPagamento> queryBase, StatusPagamentoFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusPagamentoId);
        }

    }
}

