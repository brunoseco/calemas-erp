using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class NivelAcessoOrderCustomExtension
    {

        public static IQueryable<NivelAcesso> OrderByDomain(this IQueryable<NivelAcesso> queryBase, NivelAcessoFilter filters)
        {
            return queryBase.OrderBy(_ => _.NivelAcessoId);
        }

    }
}

