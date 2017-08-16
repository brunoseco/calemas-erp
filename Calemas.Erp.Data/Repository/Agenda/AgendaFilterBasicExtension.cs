using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class AgendaFilterBasicExtension
    {

        public static IQueryable<Agenda> WithBasicFilters(this IQueryable<Agenda> queryBase, AgendaFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.AgendaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.AgendaId == filters.AgendaId);
			}
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			}
            if (filters.Descricao.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Descricao.Contains(filters.Descricao));
			}
            if (filters.DataInicioStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataInicio >= filters.DataInicioStart );
			}
            if (filters.DataInicioEnd.IsSent()) 
			{ 
				filters.DataInicioEnd = filters.DataInicioEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataInicio  <= filters.DataInicioEnd);
			}

            if (filters.DataFimStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataFim >= filters.DataFimStart );
			}
            if (filters.DataFimEnd.IsSent()) 
			{ 
				filters.DataFimEnd = filters.DataFimEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataFim  <= filters.DataFimEnd);
			}

            if (filters.CorId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CorId == filters.CorId);
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