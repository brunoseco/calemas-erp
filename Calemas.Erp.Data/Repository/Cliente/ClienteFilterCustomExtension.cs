using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class ClienteFilterCustomExtension
    {

        public static IQueryable<Cliente> WithCustomFilters(this IQueryable<Cliente> queryBase, ClienteFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.Nome.IsSent())
                queryFilter = queryFilter.Where(_ => _.Pessoa.Nome.Contains(filters.Nome));

            return queryFilter;
        }

        public static IQueryable<Cliente> WithLimitTenant(this IQueryable<Cliente> queryBase, CurrentUser user)
        {
            var tenantId = user.GetTenantId<int>();
            var queryFilter = queryBase;

            return queryFilter;
        }

    }
}

