using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IPrioridadeRepository : IRepository<Prioridade>
    {
        IQueryable<Prioridade> GetBySimplefilters(PrioridadeFilter filters);

        Task<Prioridade> GetById(PrioridadeFilter prioridade);
		
        Task<IEnumerable<dynamic>> GetDataItem(PrioridadeFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(PrioridadeFilter filters);

        Task<dynamic> GetDataCustom(PrioridadeFilter filters);
    }
}
