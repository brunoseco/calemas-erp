using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class CondominioOrderCustomExtension
    {

        public static IQueryable<Condominio> OrderByDomain(this IQueryable<Condominio> queryBase, CondominioFilter filters)
        {
            return queryBase.OrderBy(_ => _.CondominioId);
        }

    }
}

