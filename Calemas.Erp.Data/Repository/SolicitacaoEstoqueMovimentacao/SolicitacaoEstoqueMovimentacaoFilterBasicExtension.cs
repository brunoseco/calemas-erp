using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class SolicitacaoEstoqueMovimentacaoFilterBasicExtension
    {

        public static IQueryable<SolicitacaoEstoqueMovimentacao> WithBasicFilters(this IQueryable<SolicitacaoEstoqueMovimentacao> queryBase, SolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.SolicitacaoEstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SolicitacaoEstoqueMovimentacaoId == filters.SolicitacaoEstoqueMovimentacaoId);
			}
            if (filters.SolicitacaoEstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SolicitacaoEstoqueId == filters.SolicitacaoEstoqueId);
			}
            if (filters.EstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EstoqueId == filters.EstoqueId);
			}
            if (filters.Entrada.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Entrada == filters.Entrada);
			}
            if (filters.Quantidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Quantidade == filters.Quantidade);
			}


            return queryFilter;
        }

		
    }
}