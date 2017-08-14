using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IEnderecoRepository : IRepository<Endereco>
    {
        IQueryable<Endereco> GetBySimplefilters(EnderecoFilter filters);

        Task<Endereco> GetById(EnderecoFilter endereco);
		
        Task<IEnumerable<dynamic>> GetDataItem(EnderecoFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(EnderecoFilter filters);

        Task<dynamic> GetDataCustom(EnderecoFilter filters);
    }
}
