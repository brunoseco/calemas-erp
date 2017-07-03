using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class PlanoContaOrderCustomExtension
    {

        public static IQueryable<PlanoConta> OrderByDomain(this IQueryable<PlanoConta> queryBase, PlanoContaFilter filters)
        {
            return queryBase.OrderBy(_ => _.PlanoContaId);
        }

    }
}

