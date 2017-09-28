using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EstoqueFilterBasicExtension
    {

        public static IQueryable<Estoque> WithBasicFilters(this IQueryable<Estoque> queryBase, EstoqueFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.EstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EstoqueId == filters.EstoqueId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}
            if (filters.Modelo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Modelo.Contains(filters.Modelo));
			}
            if (filters.Fabricante.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Fabricante.Contains(filters.Fabricante));
			}
            if (filters.Referencia.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Referencia.Contains(filters.Referencia));
			}
            if (filters.UnidadeMedidaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UnidadeMedidaId == filters.UnidadeMedidaId);
			}
            if (filters.CategoriaEstoqueId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CategoriaEstoqueId == filters.CategoriaEstoqueId);
			}
            if (filters.Observacao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Observacao.Contains(filters.Observacao));
			}
            if (filters.QuantidadeMinima.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.QuantidadeMinima == filters.QuantidadeMinima);
			}
            if (filters.Quantidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Quantidade == filters.Quantidade);
			}
            if (filters.ValorVenda.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ValorVenda != null && _.ValorVenda.Value == filters.ValorVenda);
			}
            if (filters.ValorCompra.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ValorCompra != null && _.ValorCompra.Value == filters.ValorCompra);
			}
            if (filters.Ativo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Ativo == filters.Ativo);
			}
            if (filters.Localizacao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Localizacao.Contains(filters.Localizacao));
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