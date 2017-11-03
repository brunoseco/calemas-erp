using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class InfraestruturaPopOrderCustomExtension
    {

        public static IQueryable<InfraestruturaPop> OrderByDomain(this IQueryable<InfraestruturaPop> queryBase, InfraestruturaPopFilter filters)
        {
            return queryBase.OrderBy(_ => _.InfraestruturaPopId);
        }

    }
}

