using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class AgendaColaboradorMap : AgendaColaboradorMapBase
    {
        public AgendaColaboradorMap(EntityTypeBuilder<AgendaColaborador> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<AgendaColaborador> type)
        {

        }

    }
}