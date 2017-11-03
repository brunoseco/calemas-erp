using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IInfraestruturaSiteRepository : IRepository<InfraestruturaSite>
    {
        IQueryable<InfraestruturaSite> GetBySimplefilters(InfraestruturaSiteFilter filters);

        Task<InfraestruturaSite> GetById(InfraestruturaSiteFilter infraestruturasite);
		
        Task<IEnumerable<dynamic>> GetDataItem(InfraestruturaSiteFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(InfraestruturaSiteFilter filters);

        Task<dynamic> GetDataCustom(InfraestruturaSiteFilter filters);
    }
}
