using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class ColaboradorFilterBasicExtension
    {

        public static IQueryable<Colaborador> WithBasicFilters(this IQueryable<Colaborador> queryBase, ColaboradorFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.ColaboradorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ColaboradorId == filters.ColaboradorId);
			};
            if (filters.Account.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Account.Contains(filters.Account));
			};
            if (filters.Password.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Password.Contains(filters.Password));
			};
            if (filters.Ativo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Ativo == filters.Ativo);
			};
            if (filters.NivelAcessoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.NivelAcessoId == filters.NivelAcessoId);
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