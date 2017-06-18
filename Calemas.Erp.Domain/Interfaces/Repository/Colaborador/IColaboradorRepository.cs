using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IColaboradorRepository : IRepository<Colaborador>
    {
        IQueryable<Colaborador> GetBySimplefilters(ColaboradorFilter filters);

        Task<Colaborador> GetById(ColaboradorFilter colaborador);
		
        Task<IEnumerable<dynamic>> GetDataItem(ColaboradorFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(ColaboradorFilter filters);

        Task<dynamic> GetDataCustom(ColaboradorFilter filters);
    }
}
