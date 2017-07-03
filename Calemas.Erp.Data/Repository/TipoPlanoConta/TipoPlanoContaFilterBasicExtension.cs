using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class TipoPlanoContaFilterBasicExtension
    {

        public static IQueryable<TipoPlanoConta> WithBasicFilters(this IQueryable<TipoPlanoConta> queryBase, TipoPlanoContaFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.TipoPlanoContaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TipoPlanoContaId == filters.TipoPlanoContaId);
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};


            return queryFilter;
        }

    }
}