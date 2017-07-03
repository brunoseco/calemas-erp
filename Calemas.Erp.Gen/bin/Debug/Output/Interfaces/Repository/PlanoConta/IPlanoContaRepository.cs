using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IPlanoContaRepository : IRepository<PlanoConta>
    {
        IQueryable<PlanoConta> GetBySimplefilters(PlanoContaFilter filters);

        Task<PlanoConta> GetById(PlanoContaFilter planoconta);
		
        Task<IEnumerable<dynamic>> GetDataItem(PlanoContaFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(PlanoContaFilter filters);

        Task<dynamic> GetDataCustom(PlanoContaFilter filters);
    }
}
