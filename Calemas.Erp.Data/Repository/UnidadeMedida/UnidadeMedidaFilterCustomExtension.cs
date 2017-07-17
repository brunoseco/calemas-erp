using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class UnidadeMedidaFilterCustomExtension
    {

        public static IQueryable<UnidadeMedida> WithCustomFilters(this IQueryable<UnidadeMedida> queryBase, UnidadeMedidaFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<UnidadeMedida> WithLimitSubscriber(this IQueryable<UnidadeMedida> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

