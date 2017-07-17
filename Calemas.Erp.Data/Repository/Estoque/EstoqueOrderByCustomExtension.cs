using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EstoqueOrderCustomExtension
    {

        public static IQueryable<Estoque> OrderByDomain(this IQueryable<Estoque> queryBase, EstoqueFilter filters)
        {
            return queryBase.OrderBy(_ => _.EstoqueId);
        }

    }
}

