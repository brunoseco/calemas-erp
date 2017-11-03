using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class InfraestruturaSiteFilterBasicExtension
    {

        public static IQueryable<InfraestruturaSite> WithBasicFilters(this IQueryable<InfraestruturaSite> queryBase, InfraestruturaSiteFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.InfraestruturaSiteId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.InfraestruturaSiteId == filters.InfraestruturaSiteId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}
            if (filters.Latitude.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Latitude.Contains(filters.Latitude));
			}
            if (filters.Longitude.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Longitude.Contains(filters.Longitude));
			}
            if (filters.Endpoint.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Endpoint.Contains(filters.Endpoint));
			}
            if (filters.Login.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Login.Contains(filters.Login));
			}
            if (filters.Senha.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Senha.Contains(filters.Senha));
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