using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class FinanceiroFilterBasicExtension
    {

        public static IQueryable<Financeiro> WithBasicFilters(this IQueryable<Financeiro> queryBase, FinanceiroFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.FinanceiroId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.FinanceiroId == filters.FinanceiroId);
			};
            if (filters.DataVencimentoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataVencimento >= filters.DataVencimentoStart );
			};
            if (filters.DataVencimentoEnd.IsSent()) 
			{ 
				filters.DataVencimentoEnd = filters.DataVencimentoEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataVencimento  <= filters.DataVencimentoEnd);
			};

            if (filters.Parcela.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Parcela == filters.Parcela);
			};
            if (filters.PlanoContaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.PlanoContaId == filters.PlanoContaId);
			};
            if (filters.ValorOriginal.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ValorOriginal == filters.ValorOriginal);
			};
            if (filters.ValorDesconto.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ValorDesconto == filters.ValorDesconto);
			};
            if (filters.ValorMultaJuros.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ValorMultaJuros == filters.ValorMultaJuros);
			};
            if (filters.ValorFinal.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ValorFinal == filters.ValorFinal);
			};
            if (filters.PessoaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.PessoaId == filters.PessoaId);
			};
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			};
            if (filters.Baixado.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Baixado == filters.Baixado);
			};
            if (filters.DataBaixaStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataBaixa != null && _.DataBaixa.Value >= filters.DataBaixaStart.Value);
			};
            if (filters.DataBaixaEnd.IsSent()) 
			{ 
				filters.DataBaixaEnd = filters.DataBaixaEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataBaixa != null &&  _.DataBaixa.Value <= filters.DataBaixaEnd);
			};

            if (filters.ValorDescontoAteVencimento.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ValorDescontoAteVencimento == filters.ValorDescontoAteVencimento);
			};
            if (filters.PercentualJuros.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.PercentualJuros == filters.PercentualJuros);
			};
            if (filters.PercentualMulta.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.PercentualMulta == filters.PercentualMulta);
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