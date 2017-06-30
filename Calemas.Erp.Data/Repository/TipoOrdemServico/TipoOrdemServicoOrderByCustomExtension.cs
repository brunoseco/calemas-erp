using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class TipoOrdemServicoOrderCustomExtension
    {

        public static IQueryable<TipoOrdemServico> OrderByDomain(this IQueryable<TipoOrdemServico> queryBase, TipoOrdemServicoFilter filters)
        {
            return queryBase.OrderBy(_ => _.TipoOrdemServicoId);
        }

    }
}

