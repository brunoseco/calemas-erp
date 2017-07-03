using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IFinanceiroRepository : IRepository<Financeiro>
    {
        IQueryable<Financeiro> GetBySimplefilters(FinanceiroFilter filters);

        Task<Financeiro> GetById(FinanceiroFilter financeiro);
		
        Task<IEnumerable<dynamic>> GetDataItem(FinanceiroFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(FinanceiroFilter filters);

        Task<dynamic> GetDataCustom(FinanceiroFilter filters);
    }
}
