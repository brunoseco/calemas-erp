using Common.Domain.Model;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class StatusOrdemServicoOrderCustomExtension
    {

        public static IQueryable<StatusOrdemServico> OrderByDomain(this IQueryable<StatusOrdemServico> queryBase, StatusOrdemServicoFilter filters)
        {
            return queryBase.OrderBy(_ => _.StatusOrdemServicoId);
        }

    }
}

