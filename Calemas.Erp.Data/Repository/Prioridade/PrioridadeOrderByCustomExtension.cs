using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class PrioridadeOrderCustomExtension
    {

        public static IQueryable<Prioridade> OrderByDomain(this IQueryable<Prioridade> queryBase, PrioridadeFilter filters)
        {
            return queryBase.OrderBy(_ => _.PrioridadeId);
        }

    }
}

