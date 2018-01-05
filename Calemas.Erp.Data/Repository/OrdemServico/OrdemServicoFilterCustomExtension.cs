using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class OrdemServicoFilterCustomExtension
    {

        public static IQueryable<OrdemServico> WithCustomFilters(this IQueryable<OrdemServico> queryBase, OrdemServicoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.PrioridadeId.IsSent())
                queryFilter = queryFilter.Where(_ => _.TipoOrdemServico.PrioridadeId == filters.PrioridadeId);

            if (filters.SetorId.IsSent())
                queryFilter = queryFilter.Where(_ => _.TipoOrdemServico.SetorId == filters.SetorId);

            return queryFilter;
        }

		public static IQueryable<OrdemServico> WithLimitSubscriber(this IQueryable<OrdemServico> queryBase, CurrentUser user)
        {
            var subscriberId = user.GetSubjectId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

