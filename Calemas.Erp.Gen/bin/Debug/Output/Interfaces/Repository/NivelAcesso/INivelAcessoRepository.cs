using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface INivelAcessoRepository : IRepository<NivelAcesso>
    {
        IQueryable<NivelAcesso> GetBySimplefilters(NivelAcessoFilter filters);

        Task<NivelAcesso> GetById(NivelAcessoFilter nivelacesso);
		
        Task<IEnumerable<dynamic>> GetDataItem(NivelAcessoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(NivelAcessoFilter filters);

        Task<dynamic> GetDataCustom(NivelAcessoFilter filters);
    }
}
