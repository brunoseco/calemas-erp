using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class InfraestruturaSiteOrderCustomExtension
    {

        public static IQueryable<InfraestruturaSite> OrderByDomain(this IQueryable<InfraestruturaSite> queryBase, InfraestruturaSiteFilter filters)
        {
            return queryBase.OrderBy(_ => _.InfraestruturaSiteId);
        }

    }
}

