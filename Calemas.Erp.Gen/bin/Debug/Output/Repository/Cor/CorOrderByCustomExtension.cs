using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class CorOrderCustomExtension
    {

        public static IQueryable<Cor> OrderByDomain(this IQueryable<Cor> queryBase, CorFilter filters)
        {
            return queryBase.OrderBy(_ => _.CorId);
        }

    }
}

