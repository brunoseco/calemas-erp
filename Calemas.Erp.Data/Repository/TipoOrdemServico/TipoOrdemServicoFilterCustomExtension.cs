using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class TipoOrdemServicoFilterCustomExtension
    {

        public static IQueryable<TipoOrdemServico> WithCustomFilters(this IQueryable<TipoOrdemServico> queryBase, TipoOrdemServicoFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<TipoOrdemServico> WithLimitSubscriber(this IQueryable<TipoOrdemServico> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

