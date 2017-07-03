using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class TipoPlanoContaMap : TipoPlanoContaMapBase
    {
        public TipoPlanoContaMap(EntityTypeBuilder<TipoPlanoConta> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<TipoPlanoConta> type)
        {

        }

    }
}