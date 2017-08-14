using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IStatusOrdemServicoRepository : IRepository<StatusOrdemServico>
    {
        IQueryable<StatusOrdemServico> GetBySimplefilters(StatusOrdemServicoFilter filters);

        Task<StatusOrdemServico> GetById(StatusOrdemServicoFilter statusordemservico);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusOrdemServicoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusOrdemServicoFilter filters);

        Task<dynamic> GetDataCustom(StatusOrdemServicoFilter filters);
    }
}
