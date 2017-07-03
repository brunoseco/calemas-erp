using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface ICorRepository : IRepository<Cor>
    {
        IQueryable<Cor> GetBySimplefilters(CorFilter filters);

        Task<Cor> GetById(CorFilter cor);
		
        Task<IEnumerable<dynamic>> GetDataItem(CorFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(CorFilter filters);

        Task<dynamic> GetDataCustom(CorFilter filters);
    }
}
