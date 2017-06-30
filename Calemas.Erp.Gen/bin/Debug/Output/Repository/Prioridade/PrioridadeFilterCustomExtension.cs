using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class PrioridadeFilterCustomExtension
    {

        public static IQueryable<Prioridade> WithCustomFilters(this IQueryable<Prioridade> queryBase, PrioridadeFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Prioridade> WithLimitSubscriber(this IQueryable<Prioridade> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

