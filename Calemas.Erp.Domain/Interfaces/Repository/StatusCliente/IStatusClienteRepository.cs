using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IStatusClienteRepository : IRepository<StatusCliente>
    {
        IQueryable<StatusCliente> GetBySimplefilters(StatusClienteFilter filters);

        Task<StatusCliente> GetById(StatusClienteFilter statuscliente);
		
        Task<IEnumerable<dynamic>> GetDataItem(StatusClienteFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(StatusClienteFilter filters);

        Task<dynamic> GetDataCustom(StatusClienteFilter filters);
    }
}
