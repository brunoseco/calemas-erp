using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class StatusOrdemServicoMap : StatusOrdemServicoMapBase
    {
        public StatusOrdemServicoMap(EntityTypeBuilder<StatusOrdemServico> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<StatusOrdemServico> type)
        {

        }

    }
}