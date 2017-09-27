using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class CondominioFilterBasicExtension
    {

        public static IQueryable<Condominio> WithBasicFilters(this IQueryable<Condominio> queryBase, CondominioFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.CondominioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CondominioId == filters.CondominioId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}
            if (filters.Sigla.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Sigla.Contains(filters.Sigla));
			}
            if (filters.Ativo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Ativo == filters.Ativo);
			}
            if (filters.EnderecoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EnderecoId == filters.EnderecoId);
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