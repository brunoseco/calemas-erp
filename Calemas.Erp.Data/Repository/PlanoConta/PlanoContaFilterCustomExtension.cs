using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class PlanoContaFilterCustomExtension
    {

        public static IQueryable<PlanoConta> WithCustomFilters(this IQueryable<PlanoConta> queryBase, PlanoContaFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<PlanoConta> WithLimitSubscriber(this IQueryable<PlanoConta> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

