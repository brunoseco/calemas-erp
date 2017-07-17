using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class CategoriaEstoqueOrderCustomExtension
    {

        public static IQueryable<CategoriaEstoque> OrderByDomain(this IQueryable<CategoriaEstoque> queryBase, CategoriaEstoqueFilter filters)
        {
            return queryBase.OrderBy(_ => _.CategoriaEstoqueId);
        }

    }
}

