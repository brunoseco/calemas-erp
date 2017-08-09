using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IEstoqueRepository : IRepository<Estoque>
    {
        IQueryable<Estoque> GetBySimplefilters(EstoqueFilter filters);

        Task<Estoque> GetById(EstoqueFilter estoque);
		
        Task<IEnumerable<dynamic>> GetDataItem(EstoqueFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(EstoqueFilter filters);

        Task<dynamic> GetDataCustom(EstoqueFilter filters);
    }
}
