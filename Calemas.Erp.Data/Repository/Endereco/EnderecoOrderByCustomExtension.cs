using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class EnderecoOrderCustomExtension
    {

        public static IQueryable<Endereco> OrderByDomain(this IQueryable<Endereco> queryBase, EnderecoFilter filters)
        {
            return queryBase.OrderBy(_ => _.EnderecoId);
        }

    }
}

