using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface ICondominioRepository : IRepository<Condominio>
    {
        IQueryable<Condominio> GetBySimplefilters(CondominioFilter filters);

        Task<Condominio> GetById(CondominioFilter condominio);
		
        Task<IEnumerable<dynamic>> GetDataItem(CondominioFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(CondominioFilter filters);

        Task<dynamic> GetDataCustom(CondominioFilter filters);
    }
}
