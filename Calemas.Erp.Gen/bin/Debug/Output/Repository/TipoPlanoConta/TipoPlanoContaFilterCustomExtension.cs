using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class TipoPlanoContaFilterCustomExtension
    {

        public static IQueryable<TipoPlanoConta> WithCustomFilters(this IQueryable<TipoPlanoConta> queryBase, TipoPlanoContaFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<TipoPlanoConta> WithLimitSubscriber(this IQueryable<TipoPlanoConta> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

