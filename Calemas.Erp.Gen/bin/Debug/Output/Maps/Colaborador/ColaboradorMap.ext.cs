using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class ColaboradorMap : ColaboradorMapBase
    {
        public ColaboradorMap(EntityTypeBuilder<Colaborador> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Colaborador> type)
        {

        }

    }
}