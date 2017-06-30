using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class ColaboradorFilterCustomExtension
    {

        public static IQueryable<Colaborador> WithCustomFilters(this IQueryable<Colaborador> queryBase, ColaboradorFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Colaborador> WithLimitSubscriber(this IQueryable<Colaborador> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

