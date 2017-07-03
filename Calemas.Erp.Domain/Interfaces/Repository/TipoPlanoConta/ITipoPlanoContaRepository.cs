using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface ITipoPlanoContaRepository : IRepository<TipoPlanoConta>
    {
        IQueryable<TipoPlanoConta> GetBySimplefilters(TipoPlanoContaFilter filters);

        Task<TipoPlanoConta> GetById(TipoPlanoContaFilter tipoplanoconta);
		
        Task<IEnumerable<dynamic>> GetDataItem(TipoPlanoContaFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(TipoPlanoContaFilter filters);

        Task<dynamic> GetDataCustom(TipoPlanoContaFilter filters);
    }
}
