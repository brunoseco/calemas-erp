using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class AgendaColaboradorFilterCustomExtension
    {

        public static IQueryable<AgendaColaborador> WithCustomFilters(this IQueryable<AgendaColaborador> queryBase, AgendaColaboradorFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<AgendaColaborador> WithLimitTenant(this IQueryable<AgendaColaborador> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

