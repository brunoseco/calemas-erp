using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class ClienteFilterBasicExtension
    {

        public static IQueryable<Cliente> WithBasicFilters(this IQueryable<Cliente> queryBase, ClienteFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.ClienteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ClienteId == filters.ClienteId);
			}
            if (filters.StatusClienteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusClienteId == filters.StatusClienteId);
			}
            if (filters.CondominioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CondominioId != null && _.CondominioId.Value == filters.CondominioId);
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