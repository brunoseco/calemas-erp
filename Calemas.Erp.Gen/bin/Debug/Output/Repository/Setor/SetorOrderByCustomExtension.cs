using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class SetorOrderCustomExtension
    {

        public static IQueryable<Setor> OrderByDomain(this IQueryable<Setor> queryBase, SetorFilter filters)
        {
            return queryBase.OrderBy(_ => _.SetorId);
        }

    }
}

