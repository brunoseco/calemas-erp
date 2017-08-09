using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IEstoqueMovimentacaoRepository : IRepository<EstoqueMovimentacao>
    {
        IQueryable<EstoqueMovimentacao> GetBySimplefilters(EstoqueMovimentacaoFilter filters);

        Task<EstoqueMovimentacao> GetById(EstoqueMovimentacaoFilter estoquemovimentacao);
		
        Task<IEnumerable<dynamic>> GetDataItem(EstoqueMovimentacaoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(EstoqueMovimentacaoFilter filters);

        Task<dynamic> GetDataCustom(EstoqueMovimentacaoFilter filters);
    }
}
