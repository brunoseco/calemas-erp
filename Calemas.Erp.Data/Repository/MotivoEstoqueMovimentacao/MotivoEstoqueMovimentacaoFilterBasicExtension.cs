using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class MotivoEstoqueMovimentacaoFilterBasicExtension
    {

        public static IQueryable<MotivoEstoqueMovimentacao> WithBasicFilters(this IQueryable<MotivoEstoqueMovimentacao> queryBase, MotivoEstoqueMovimentacaoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.MotivoEstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.MotivoEstoqueMovimentacaoId == filters.MotivoEstoqueMovimentacaoId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }

		
    }
}