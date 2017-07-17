using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class CategoriaEstoqueFilterCustomExtension
    {

        public static IQueryable<CategoriaEstoque> WithCustomFilters(this IQueryable<CategoriaEstoque> queryBase, CategoriaEstoqueFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<CategoriaEstoque> WithLimitSubscriber(this IQueryable<CategoriaEstoque> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

