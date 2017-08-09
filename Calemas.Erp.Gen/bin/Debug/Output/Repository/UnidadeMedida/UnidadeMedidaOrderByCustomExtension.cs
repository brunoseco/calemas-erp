using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class UnidadeMedidaOrderCustomExtension
    {

        public static IQueryable<UnidadeMedida> OrderByDomain(this IQueryable<UnidadeMedida> queryBase, UnidadeMedidaFilter filters)
        {
            return queryBase.OrderBy(_ => _.UnidadeMedidaId);
        }

    }
}

