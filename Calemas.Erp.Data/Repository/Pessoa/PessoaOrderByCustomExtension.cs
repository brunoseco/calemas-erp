using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class PessoaOrderCustomExtension
    {

        public static IQueryable<Pessoa> OrderByDomain(this IQueryable<Pessoa> queryBase, PessoaFilter filters)
        {
            return queryBase.OrderBy(_ => _.PessoaId);
        }

    }
}

