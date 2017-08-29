using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class AgendaFilterCustomExtension
    {

        public static IQueryable<Agenda> WithCustomFilters(this IQueryable<Agenda> queryBase, AgendaFilter filters, CurrentUser user)
        {
            var queryFilter = queryBase;

            if (filters.ColaboradorId.IsSent())
                queryFilter = queryFilter.Where(_ => _.CollectionAgendaColaborador.Where(__ => __.ColaboradorId == filters.ColaboradorId).Any());

            return queryFilter;
        }

        public static IQueryable<Agenda> WithLimitTenant(this IQueryable<Agenda> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
            var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

