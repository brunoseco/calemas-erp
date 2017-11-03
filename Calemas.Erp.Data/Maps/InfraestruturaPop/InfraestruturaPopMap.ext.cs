using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class InfraestruturaPopMap : InfraestruturaPopMapBase
    {
        public InfraestruturaPopMap(EntityTypeBuilder<InfraestruturaPop> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<InfraestruturaPop> type)
        {

        }

    }
}