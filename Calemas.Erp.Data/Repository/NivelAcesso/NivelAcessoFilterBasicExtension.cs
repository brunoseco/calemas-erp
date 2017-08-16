using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class NivelAcessoFilterBasicExtension
    {

        public static IQueryable<NivelAcesso> WithBasicFilters(this IQueryable<NivelAcesso> queryBase, NivelAcessoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.NivelAcessoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.NivelAcessoId == filters.NivelAcessoId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }

		
    }
}