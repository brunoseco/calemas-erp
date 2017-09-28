using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface ISolicitacaoEstoqueMovimentacaoRepository : IRepository<SolicitacaoEstoqueMovimentacao>
    {
        IQueryable<SolicitacaoEstoqueMovimentacao> GetBySimplefilters(SolicitacaoEstoqueMovimentacaoFilter filters);

        Task<SolicitacaoEstoqueMovimentacao> GetById(SolicitacaoEstoqueMovimentacaoFilter solicitacaoestoquemovimentacao);
		
        Task<IEnumerable<dynamic>> GetDataItem(SolicitacaoEstoqueMovimentacaoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(SolicitacaoEstoqueMovimentacaoFilter filters);

        Task<dynamic> GetDataCustom(SolicitacaoEstoqueMovimentacaoFilter filters);
    }
}
