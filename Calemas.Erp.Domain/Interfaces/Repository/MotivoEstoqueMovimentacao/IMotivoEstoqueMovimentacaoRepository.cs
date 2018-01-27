using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IMotivoEstoqueMovimentacaoRepository : IRepository<MotivoEstoqueMovimentacao>
    {
        IQueryable<MotivoEstoqueMovimentacao> GetBySimplefilters(MotivoEstoqueMovimentacaoFilter filters);

        Task<MotivoEstoqueMovimentacao> GetById(MotivoEstoqueMovimentacaoFilter motivoestoquemovimentacao);
		
        Task<IEnumerable<dynamic>> GetDataItem(MotivoEstoqueMovimentacaoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(MotivoEstoqueMovimentacaoFilter filters);

        Task<dynamic> GetDataCustom(MotivoEstoqueMovimentacaoFilter filters);
    }
}
