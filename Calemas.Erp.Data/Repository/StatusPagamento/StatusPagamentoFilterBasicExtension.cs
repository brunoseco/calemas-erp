using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusPagamentoFilterBasicExtension
    {

        public static IQueryable<StatusPagamento> WithBasicFilters(this IQueryable<StatusPagamento> queryBase, StatusPagamentoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.StatusPagamentoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusPagamentoId == filters.StatusPagamentoId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }

		
    }
}