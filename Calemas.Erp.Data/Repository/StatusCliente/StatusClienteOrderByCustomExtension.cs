using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusClienteOrderCustomExtension
    {

        public static IQueryable<StatusCliente> OrderByDomain(this IQueryable<StatusCliente> queryBase, StatusClienteFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusClienteId);
        }

    }
}

