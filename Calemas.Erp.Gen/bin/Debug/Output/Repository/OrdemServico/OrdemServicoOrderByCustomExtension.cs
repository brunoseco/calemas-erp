using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class OrdemServicoOrderCustomExtension
    {

        public static IQueryable<OrdemServico> OrderByDomain(this IQueryable<OrdemServico> queryBase, OrdemServicoFilter filters)
        {
            return queryBase.OrderBy(_ => _.OrdemServicoId);
        }

    }
}

