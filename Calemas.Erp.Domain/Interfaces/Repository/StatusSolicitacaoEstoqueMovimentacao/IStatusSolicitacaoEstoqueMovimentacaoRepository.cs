using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IStatusSolicitacaoEstoqueMovimentacaoRepository : IRepository<StatusSolicitacaoEstoqueMovimentacao>
    {
        IQueryable<StatusSolicitacaoEstoqueMovimentacao> GetBySimplefilters(StatusSolicitacaoEstoqueMovimentacaoFilter filters);

        Task<StatusSolicitacaoEstoqueMovimentacao> GetById(StatusSolicitacaoEstoqueMovimentacaoFilter statussolicitacaoestoquemovimentacao);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusSolicitacaoEstoqueMovimentacaoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusSolicitacaoEstoqueMovimentacaoFilter filters);

        Task<dynamic> GetDataCustom(StatusSolicitacaoEstoqueMovimentacaoFilter filters);
    }
}
