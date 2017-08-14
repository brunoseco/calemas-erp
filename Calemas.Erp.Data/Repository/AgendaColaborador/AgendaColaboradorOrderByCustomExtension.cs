using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class AgendaColaboradorOrderCustomExtension
    {

        public static IQueryable<AgendaColaborador> OrderByDomain(this IQueryable<AgendaColaborador> queryBase, AgendaColaboradorFilter filters)
        {
            return queryBase.OrderBy(_ => _.AgendaId).ThenBy(_ => _.ColaboradorId);
        }

    }
}

