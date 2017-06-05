using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class BancoFilterCustomExtension
    {

        public static IQueryable<Banco> WithCustomFilters(this IQueryable<Banco> queryBase, BancoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Banco> WithLimitSubscriber(this IQueryable<Banco> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubscriberId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

