using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class UnidadeMedidaMap : UnidadeMedidaMapBase
    {
        public UnidadeMedidaMap(EntityTypeBuilder<UnidadeMedida> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<UnidadeMedida> type)
        {

        }

    }
}