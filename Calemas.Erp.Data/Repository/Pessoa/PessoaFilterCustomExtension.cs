using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class PessoaFilterCustomExtension
    {

        public static IQueryable<Pessoa> WithCustomFilters(this IQueryable<Pessoa> queryBase, PessoaFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<Pessoa> WithLimitSubscriber(this IQueryable<Pessoa> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

