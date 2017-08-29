using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class OrdemServicoInteracaoFilterBasicExtension
    {

        public static IQueryable<OrdemServicoInteracao> WithBasicFilters(this IQueryable<OrdemServicoInteracao> queryBase, OrdemServicoInteracaoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.OrdemServicoInteracaoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.OrdemServicoInteracaoId == filters.OrdemServicoInteracaoId);
			}
            if (filters.OrdemServicoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.OrdemServicoId == filters.OrdemServicoId);
			}
            if (filters.DataConclusaoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataConclusao >= filters.DataConclusaoStart );
			}
            if (filters.DataConclusaoEnd.IsSent()) 
			{ 
				filters.DataConclusaoEnd = filters.DataConclusaoEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataConclusao  <= filters.DataConclusaoEnd);
			}

            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}
            if (filters.Observacao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Observacao.Contains(filters.Observacao));
			}
            if (filters.FoiProprioCliente.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.FoiProprioCliente == filters.FoiProprioCliente);
			}
            if (filters.NomeClienteResponsavel.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.NomeClienteResponsavel.Contains(filters.NomeClienteResponsavel));
			}
            if (filters.TecnicoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TecnicoId == filters.TecnicoId);
			}
            if (filters.StatusOrdemServicoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusOrdemServicoId == filters.StatusOrdemServicoId);
			}


            return queryFilter;
        }

		
    }
}