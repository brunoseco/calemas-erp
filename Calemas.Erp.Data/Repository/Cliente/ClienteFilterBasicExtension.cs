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
			};
            if (filters.StatusClienteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.StatusClienteId == filters.StatusClienteId);
			};
            if (filters.CondominioId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CondominioId != null && _.CondominioId.Value == filters.CondominioId);
			};
            if (filters.ResponsavelId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.ResponsavelId == filters.ResponsavelId);
			};


            return queryFilter;
        }

    }
}