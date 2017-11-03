using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class InfraestruturaSiteFilterCustomExtension
    {

        public static IQueryable<InfraestruturaSite> WithCustomFilters(this IQueryable<InfraestruturaSite> queryBase, InfraestruturaSiteFilter filters)
        {
            var queryFilter = queryBase;


            return queryFilter;
        }

		public static IQueryable<InfraestruturaSite> WithLimitTenant(this IQueryable<InfraestruturaSite> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
			var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

