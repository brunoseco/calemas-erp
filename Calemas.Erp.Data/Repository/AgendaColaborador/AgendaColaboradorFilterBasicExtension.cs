using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class AgendaColaboradorFilterBasicExtension
    {

        public static IQueryable<AgendaColaborador> WithBasicFilters(this IQueryable<AgendaColaborador> queryBase, AgendaColaboradorFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.AgendaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.AgendaId == filters.AgendaId);
			}
            if (filters.ColaboradorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ColaboradorId == filters.ColaboradorId);
			}


            return queryFilter;
        }

		
    }
}