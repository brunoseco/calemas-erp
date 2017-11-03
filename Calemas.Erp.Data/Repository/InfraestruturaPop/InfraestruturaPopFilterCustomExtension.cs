using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class InfraestruturaPopFilterCustomExtension
    {

        public static IQueryable<InfraestruturaPop> WithCustomFilters(this IQueryable<InfraestruturaPop> queryBase, InfraestruturaPopFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<InfraestruturaPop> WithLimitTenant(this IQueryable<InfraestruturaPop> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

