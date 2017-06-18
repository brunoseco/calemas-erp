using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class ColaboradorOrderCustomExtension
    {

        public static IQueryable<Colaborador> OrderByDomain(this IQueryable<Colaborador> queryBase, ColaboradorFilter filters)
        {
            return queryBase.OrderBy(_ => _.ColaboradorId);
        }

    }
}

