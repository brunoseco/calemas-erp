using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EstoqueMovimentacaoFilterBasicExtension
    {

        public static IQueryable<EstoqueMovimentacao> WithBasicFilters(this IQueryable<EstoqueMovimentacao> queryBase, EstoqueMovimentacaoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.EstoqueMovimentacaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EstoqueMovimentacaoId == filters.EstoqueMovimentacaoId);
			};
            if (filters.EstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EstoqueId == filters.EstoqueId);
			};
            if (filters.Entrada.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Entrada == filters.Entrada);
			};
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			};
            if (filters.Quantidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Quantidade == filters.Quantidade);
			};
            if (filters.ResponsavelId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ResponsavelId == filters.ResponsavelId);
			};
            if (filters.UserCreateId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserCreateId == filters.UserCreateId);
			};
            if (filters.UserCreateDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserCreateDate >= filters.UserCreateDateStart );
			};
            if (filters.UserCreateDateEnd.IsSent()) 
			{ 
				filters.UserCreateDateEnd = filters.UserCreateDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.UserCreateDate  <= filters.UserCreateDateEnd);
			};

            if (filters.UserAlterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterId != null && _.UserAlterId.Value == filters.UserAlterId);
			};
            if (filters.UserAlterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterDate != null && _.UserAlterDate.Value >= filters.UserAlterDateStart.Value);
			};
            if (filters.UserAlterDateEnd.IsSent()) 
			{ 
				filters.UserAlterDateEnd = filters.UserAlterDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.UserAlterDate != null &&  _.UserAlterDate.Value <= filters.UserAlterDateEnd);
			};



            return queryFilter;
        }

    }
}