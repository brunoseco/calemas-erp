using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class SetorMap : SetorMapBase
    {
        public SetorMap(EntityTypeBuilder<Setor> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Setor> type)
        {

        }

    }
}