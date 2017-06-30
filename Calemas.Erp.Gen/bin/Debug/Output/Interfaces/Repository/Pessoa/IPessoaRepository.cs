using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IPessoaRepository : IRepository<Pessoa>
    {
        IQueryable<Pessoa> GetBySimplefilters(PessoaFilter filters);

        Task<Pessoa> GetById(PessoaFilter pessoa);
		
        Task<IEnumerable<dynamic>> GetDataItem(PessoaFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(PessoaFilter filters);

        Task<dynamic> GetDataCustom(PessoaFilter filters);
    }
}
