using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class BancoFilterBasicExtension
    {

        public static IQueryable<Banco> WithBasicFilters(this IQueryable<Banco> queryBase, BancoFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.BancoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.BancoId == filters.BancoId);
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};
            if (filters.Numero.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Numero.Contains(filters.Numero));
			};
            if (filters.Digito.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Digito.Contains(filters.Digito));
			};
            if (filters.BoletoSemRegistro.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.BoletoSemRegistro == filters.BoletoSemRegistro);
			};
            if (filters.BoletoComRegistro.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.BoletoComRegistro == filters.BoletoComRegistro);
			};
            if (filters.Ativo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Ativo == filters.Ativo);
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