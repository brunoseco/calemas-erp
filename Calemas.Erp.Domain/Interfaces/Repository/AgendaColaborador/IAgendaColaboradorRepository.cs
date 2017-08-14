using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IAgendaColaboradorRepository : IRepository<AgendaColaborador>
    {
        IQueryable<AgendaColaborador> GetBySimplefilters(AgendaColaboradorFilter filters);

        Task<AgendaColaborador> GetById(AgendaColaboradorFilter agendacolaborador);
		
        Task<IEnumerable<dynamic>> GetDataItem(AgendaColaboradorFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(AgendaColaboradorFilter filters);

        Task<dynamic> GetDataCustom(AgendaColaboradorFilter filters);
    }
}
