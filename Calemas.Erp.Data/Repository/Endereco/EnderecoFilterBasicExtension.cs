using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EnderecoFilterBasicExtension
    {

        public static IQueryable<Endereco> WithBasicFilters(this IQueryable<Endereco> queryBase, EnderecoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.EnderecoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EnderecoId == filters.EnderecoId);
			};
            if (filters.CEP.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CEP.Contains(filters.CEP));
			};
            if (filters.Rua.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Rua.Contains(filters.Rua));
			};
            if (filters.Numero.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Numero.Contains(filters.Numero));
			};
            if (filters.Complemento.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Complemento.Contains(filters.Complemento));
			};
            if (filters.PontoReferencia.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.PontoReferencia.Contains(filters.PontoReferencia));
			};
            if (filters.Cidade.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Cidade.Contains(filters.Cidade));
			};
            if (filters.EstadoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EstadoId != null && _.EstadoId.Value == filters.EstadoId);
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