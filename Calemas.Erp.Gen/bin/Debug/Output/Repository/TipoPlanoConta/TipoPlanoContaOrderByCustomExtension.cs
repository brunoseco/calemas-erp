using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class TipoPlanoContaOrderCustomExtension
    {

        public static IQueryable<TipoPlanoConta> OrderByDomain(this IQueryable<TipoPlanoConta> queryBase, TipoPlanoContaFilter filters)
        {
            return queryBase.OrderBy(_ => _.TipoPlanoContaId);
        }

    }
}

