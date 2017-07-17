using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class CategoriaEstoqueFilterBasicExtension
    {

        public static IQueryable<CategoriaEstoque> WithBasicFilters(this IQueryable<CategoriaEstoque> queryBase, CategoriaEstoqueFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.CategoriaEstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CategoriaEstoqueId == filters.CategoriaEstoqueId);
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};


            return queryFilter;
        }

    }
}