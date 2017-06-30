using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class TipoOrdemServicoMap : TipoOrdemServicoMapBase
    {
        public TipoOrdemServicoMap(EntityTypeBuilder<TipoOrdemServico> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TipoOrdemServico> type)
        {

        }

    }
}