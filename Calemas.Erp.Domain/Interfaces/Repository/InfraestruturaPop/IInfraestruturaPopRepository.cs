using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IInfraestruturaPopRepository : IRepository<InfraestruturaPop>
    {
        IQueryable<InfraestruturaPop> GetBySimplefilters(InfraestruturaPopFilter filters);

        Task<InfraestruturaPop> GetById(InfraestruturaPopFilter infraestruturapop);
		
        Task<IEnumerable<dynamic>> GetDataItem(InfraestruturaPopFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(InfraestruturaPopFilter filters);

        Task<dynamic> GetDataCustom(InfraestruturaPopFilter filters);
    }
}
