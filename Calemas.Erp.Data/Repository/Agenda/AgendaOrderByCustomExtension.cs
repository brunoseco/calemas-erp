using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class AgendaOrderCustomExtension
    {

        public static IQueryable<Agenda> OrderByDomain(this IQueryable<Agenda> queryBase, AgendaFilter filters)
        {
            return queryBase.OrderBy(_ => _.AgendaId);
        }

    }
}

