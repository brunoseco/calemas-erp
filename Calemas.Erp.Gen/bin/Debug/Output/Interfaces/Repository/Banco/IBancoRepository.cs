using Common.Domain.Interfaces;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Collections.Generic;
using System.Linq;


namespace Calemas.Erp.Domain.Interfaces.Repository
{
    public interface IBancoRepository : IRepository<Banco>
    {
        IQueryable<Banco> GetBySimplefilters(BancoFilter filters);

        Banco GetById(BancoFilter banco);
		
        IEnumerable<dynamic> GetDataItem(BancoFilter filters);

        IEnumerable<dynamic> GetDataListCustom(BancoFilter filters);

        dynamic GetDataCustom(BancoFilter filters);
    }
}
