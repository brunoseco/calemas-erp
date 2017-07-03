using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class CorFilterBasicExtension
    {

        public static IQueryable<Cor> WithBasicFilters(this IQueryable<Cor> queryBase, CorFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.CorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CorId == filters.CorId);
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};
            if (filters.Hash.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Hash.Contains(filters.Hash));
			};


            return queryFilter;
        }

    }
}