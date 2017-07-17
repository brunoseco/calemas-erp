using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface ICategoriaEstoqueRepository : IRepository<CategoriaEstoque>
    {
        IQueryable<CategoriaEstoque> GetBySimplefilters(CategoriaEstoqueFilter filters);

        Task<CategoriaEstoque> GetById(CategoriaEstoqueFilter categoriaestoque);
		
        Task<IEnumerable<dynamic>> GetDataItem(CategoriaEstoqueFilter filters);

        Task<IEnumerable<dynamic>> GetDataListCustom(CategoriaEstoqueFilter filters);

        Task<dynamic> GetDataCustom(CategoriaEstoqueFilter filters);
    }
}
