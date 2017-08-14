using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IOrdemServicoInteracaoRepository : IRepository<OrdemServicoInteracao>
    {
        IQueryable<OrdemServicoInteracao> GetBySimplefilters(OrdemServicoInteracaoFilter filters);

        Task<OrdemServicoInteracao> GetById(OrdemServicoInteracaoFilter ordemservicointeracao);
		
        Task<IEnumerable<dynamic>> GetDataItem(OrdemServicoInteracaoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(OrdemServicoInteracaoFilter filters);

        Task<dynamic> GetDataCustom(OrdemServicoInteracaoFilter filters);
    }
}
