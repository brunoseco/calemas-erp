using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface ISolicitacaoEstoqueRepository : IRepository<SolicitacaoEstoque>
    {
        IQueryable<SolicitacaoEstoque> GetBySimplefilters(SolicitacaoEstoqueFilter filters);

        Task<SolicitacaoEstoque> GetById(SolicitacaoEstoqueFilter solicitacaoestoque);
		
        Task<IEnumerable<dynamic>> GetDataItem(SolicitacaoEstoqueFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(SolicitacaoEstoqueFilter filters);

        Task<dynamic> GetDataCustom(SolicitacaoEstoqueFilter filters);
    }
}
