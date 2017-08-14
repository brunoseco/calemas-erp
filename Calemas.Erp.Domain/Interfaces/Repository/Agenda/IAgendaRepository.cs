using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IAgendaRepository : IRepository<Agenda>
    {
        IQueryable<Agenda> GetBySimplefilters(AgendaFilter filters);

        Task<Agenda> GetById(AgendaFilter agenda);
		
        Task<IEnumerable<dynamic>> GetDataItem(AgendaFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(AgendaFilter filters);

        Task<dynamic> GetDataCustom(AgendaFilter filters);
    }
}
