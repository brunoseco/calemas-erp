using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class FinanceiroFilterCustomExtension
    {

        public static IQueryable<Financeiro> WithCustomFilters(this IQueryable<Financeiro> queryBase, FinanceiroFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Financeiro> WithLimitSubscriber(this IQueryable<Financeiro> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

