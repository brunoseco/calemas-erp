using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IOrdemServicoRepository : IRepository<OrdemServico>
    {
        IQueryable<OrdemServico> GetBySimplefilters(OrdemServicoFilter filters);

        Task<OrdemServico> GetById(OrdemServicoFilter ordemservico);
		
        Task<IEnumerable<dynamic>> GetDataItem(OrdemServicoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(OrdemServicoFilter filters);

        Task<dynamic> GetDataCustom(OrdemServicoFilter filters);
    }
}
