using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        IQueryable<Cliente> GetBySimplefilters(ClienteFilter filters);

        Task<Cliente> GetById(ClienteFilter cliente);
		
        Task<IEnumerable<dynamic>> GetDataItem(ClienteFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(ClienteFilter filters);

        Task<dynamic> GetDataCustom(ClienteFilter filters);
    }
}
