using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IEstoqueMovimentacaoColaboradorRepository : IRepository<EstoqueMovimentacaoColaborador>
    {
        IQueryable<EstoqueMovimentacaoColaborador> GetBySimplefilters(EstoqueMovimentacaoColaboradorFilter filters);

        Task<EstoqueMovimentacaoColaborador> GetById(EstoqueMovimentacaoColaboradorFilter estoquemovimentacaocolaborador);
		
        Task<IEnumerable<dynamic>> GetDataItem(EstoqueMovimentacaoColaboradorFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(EstoqueMovimentacaoColaboradorFilter filters);

        Task<dynamic> GetDataCustom(EstoqueMovimentacaoColaboradorFilter filters);
    }
}
