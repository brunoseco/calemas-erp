using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class FinanceiroOrderCustomExtension
    {

        public static IQueryable<Financeiro> OrderByDomain(this IQueryable<Financeiro> queryBase, FinanceiroFilter filters)
        {
            return queryBase.OrderBy(_ => _.FinanceiroId);
        }

    }
}

