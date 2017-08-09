using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class OrdemServicoFilterBasicExtension
    {

        public static IQueryable<OrdemServico> WithBasicFilters(this IQueryable<OrdemServico> queryBase, OrdemServicoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.OrdemServicoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.OrdemServicoId == filters.OrdemServicoId);
			};
            if (filters.Protoco.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Protoco.Contains(filters.Protoco));
			};
            if (filters.ResponsavelId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ResponsavelId == filters.ResponsavelId);
			};
            if (filters.ClienteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ClienteId == filters.ClienteId);
			};
            if (filters.PrioridadeId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.PrioridadeId == filters.PrioridadeId);
			};
            if (filters.SetorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.SetorId == filters.SetorId);
			};
            if (filters.TipoOrdemServicoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.TipoOrdemServicoId == filters.TipoOrdemServicoId);
			};
            if (filters.AgendaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.AgendaId == filters.AgendaId);
			};
            if (filters.StatusOrdemServicoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusOrdemServicoId == filters.StatusOrdemServicoId);
			};
            if (filters.DataOcorrenciaStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataOcorrencia >= filters.DataOcorrenciaStart );
			};
            if (filters.DataOcorrenciaEnd.IsSent()) 
			{ 
				filters.DataOcorrenciaEnd = filters.DataOcorrenciaEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataOcorrencia  <= filters.DataOcorrenciaEnd);
			};

            if (filters.DataSituacaoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataSituacao >= filters.DataSituacaoStart );
			};
            if (filters.DataSituacaoEnd.IsSent()) 
			{ 
				filters.DataSituacaoEnd = filters.DataSituacaoEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataSituacao  <= filters.DataSituacaoEnd);
			};

            if (filters.Observacao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Observacao.Contains(filters.Observacao));
			};
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
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