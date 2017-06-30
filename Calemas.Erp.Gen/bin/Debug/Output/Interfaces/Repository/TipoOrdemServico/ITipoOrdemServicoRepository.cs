using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface ITipoOrdemServicoRepository : IRepository<TipoOrdemServico>
    {
        IQueryable<TipoOrdemServico> GetBySimplefilters(TipoOrdemServicoFilter filters);

        Task<TipoOrdemServico> GetById(TipoOrdemServicoFilter tipoordemservico);
		
        Task<IEnumerable<dynamic>> GetDataItem(TipoOrdemServicoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(TipoOrdemServicoFilter filters);

        Task<dynamic> GetDataCustom(TipoOrdemServicoFilter filters);
    }
}
