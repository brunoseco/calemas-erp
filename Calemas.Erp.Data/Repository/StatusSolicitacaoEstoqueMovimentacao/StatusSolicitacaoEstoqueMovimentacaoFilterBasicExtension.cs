using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusSolicitacaoEstoqueMovimentacaoFilterBasicExtension
    {

        public static IQueryable<StatusSolicitacaoEstoqueMovimentacao> WithBasicFilters(this IQueryable<StatusSolicitacaoEstoqueMovimentacao> queryBase, StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.StatusSolicitacaoEstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusSolicitacaoEstoqueMovimentacaoId == filters.StatusSolicitacaoEstoqueMovimentacaoId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}


            return queryFilter;
        }

		
    }
}