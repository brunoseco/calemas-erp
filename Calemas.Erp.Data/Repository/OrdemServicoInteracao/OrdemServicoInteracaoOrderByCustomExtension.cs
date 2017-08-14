using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class OrdemServicoInteracaoOrderCustomExtension
    {

        public static IQueryable<OrdemServicoInteracao> OrderByDomain(this IQueryable<OrdemServicoInteracao> queryBase, OrdemServicoInteracaoFilter filters)
        {
            return queryBase.OrderBy(_ => _.OrdemServicoInteracaoId);
        }

    }
}

