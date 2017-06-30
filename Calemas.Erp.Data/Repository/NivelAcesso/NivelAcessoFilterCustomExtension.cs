using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class NivelAcessoFilterCustomExtension
    {

        public static IQueryable<NivelAcesso> WithCustomFilters(this IQueryable<NivelAcesso> queryBase, NivelAcessoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<NivelAcesso> WithLimitSubscriber(this IQueryable<NivelAcesso> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

