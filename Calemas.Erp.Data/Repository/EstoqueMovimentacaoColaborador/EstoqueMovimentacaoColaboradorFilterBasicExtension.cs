using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EstoqueMovimentacaoColaboradorFilterBasicExtension
    {

        public static IQueryable<EstoqueMovimentacaoColaborador> WithBasicFilters(this IQueryable<EstoqueMovimentacaoColaborador> queryBase, EstoqueMovimentacaoColaboradorFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.EstoqueMovimentacaoColaboradorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EstoqueMovimentacaoColaboradorId == filters.EstoqueMovimentacaoColaboradorId);
			}
            if (filters.ColaboradorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ColaboradorId == filters.ColaboradorId);
			}
            if (filters.Entrada.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Entrada == filters.Entrada);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}
            if (filters.Quantidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Quantidade == filters.Quantidade);
			}


            return queryFilter;
        }

		
    }
}