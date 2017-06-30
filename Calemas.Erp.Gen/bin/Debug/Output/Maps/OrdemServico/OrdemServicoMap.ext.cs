using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class OrdemServicoMap : OrdemServicoMapBase
    {
        public OrdemServicoMap(EntityTypeBuilder<OrdemServico> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<OrdemServico> type)
        {

        }

    }
}