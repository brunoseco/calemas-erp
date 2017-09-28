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
            if (filters.EstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EstoqueId == filters.EstoqueId);
			}
            if (filters.Entrada.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Entrada == filters.Entrada);
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}
            if (filters.SolicitanteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SolicitanteId == filters.SolicitanteId);
			}
            if (filters.DataSolicitacaoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataSolicitacao >= filters.DataSolicitacaoStart );
			}
            if (filters.DataSolicitacaoEnd.IsSent()) 
			{ 
				filters.DataSolicitacaoEnd = filters.DataSolicitacaoEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataSolicitacao  <= filters.DataSolicitacaoEnd);
			}

            if (filters.DataPrevistaStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataPrevista >= filters.DataPrevistaStart );
			}
            if (filters.DataPrevistaEnd.IsSent()) 
			{ 
				filters.DataPrevistaEnd = filters.DataPrevistaEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataPrevista  <= filters.DataPrevistaEnd);
			}

            if (filters.StatusSolicitacaoEstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusSolicitacaoEstoqueMovimentacaoId == filters.StatusSolicitacaoEstoqueMovimentacaoId);
			}
            if (filters.Quantidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Quantidade == filters.Quantidade);
			}
            if (filters.UserCreateId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserCreateId == filters.UserCreateId);
			}
            if (filters.UserCreateDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserCreateDate >= filters.UserCreateDateStart );
			}
            if (filters.UserCreateDateEnd.IsSent()) 
			{ 
				filters.UserCreateDateEnd = filters.UserCreateDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.UserCreateDate  <= filters.UserCreateDateEnd);
			}

            if (filters.UserAlterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterId != null && _.UserAlterId.Value == filters.UserAlterId);
			}
            if (filters.UserAlterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterDate != null && _.UserAlterDate.Value >= filters.UserAlterDateStart.Value);
			}
            if (filters.UserAlterDateEnd.IsSent()) 
			{ 
				filters.UserAlterDateEnd = filters.UserAlterDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.UserAlterDate != null &&  _.UserAlterDate.Value <= filters.UserAlterDateEnd);
			}



            return queryFilter;
        }

		
    }
}