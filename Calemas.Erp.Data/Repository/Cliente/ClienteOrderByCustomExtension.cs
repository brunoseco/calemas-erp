using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class ClienteOrderCustomExtension
    {

        public static IQueryable<Cliente> OrderByDomain(this IQueryable<Cliente> queryBase, ClienteFilter filters)
        {
            return queryBase.OrderBy(_ => _.ClienteId);
        }

    }
}

