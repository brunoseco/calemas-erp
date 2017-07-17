using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class UnidadeMedidaFilterBasicExtension
    {

        public static IQueryable<UnidadeMedida> WithBasicFilters(this IQueryable<UnidadeMedida> queryBase, UnidadeMedidaFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.UnidadeMedidaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UnidadeMedidaId == filters.UnidadeMedidaId);
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};


            return queryFilter;
        }

    }
}