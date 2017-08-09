using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IUnidadeMedidaRepository : IRepository<UnidadeMedida>
    {
        IQueryable<UnidadeMedida> GetBySimplefilters(UnidadeMedidaFilter filters);

        Task<UnidadeMedida> GetById(UnidadeMedidaFilter unidademedida);
		
        Task<IEnumerable<dynamic>> GetDataItem(UnidadeMedidaFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(UnidadeMedidaFilter filters);

        Task<dynamic> GetDataCustom(UnidadeMedidaFilter filters);
    }
}
