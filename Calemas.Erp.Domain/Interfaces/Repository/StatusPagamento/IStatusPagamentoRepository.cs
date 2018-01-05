using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IStatusPagamentoRepository : IRepository<StatusPagamento>
    {
        IQueryable<StatusPagamento> GetBySimplefilters(StatusPagamentoFilter filters);

        Task<StatusPagamento> GetById(StatusPagamentoFilter statuspagamento);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusPagamentoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusPagamentoFilter filters);

        Task<dynamic> GetDataCustom(StatusPagamentoFilter filters);
    }
}
