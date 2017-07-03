using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class PlanoContaFilterBasicExtension
    {

        public static IQueryable<PlanoConta> WithBasicFilters(this IQueryable<PlanoConta> queryBase, PlanoContaFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.PlanoContaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.PlanoContaId == filters.PlanoContaId);
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			};
            if (filters.TipoPlanoContaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TipoPlanoContaId == filters.TipoPlanoContaId);
			};


            return queryFilter;
        }

    }
}