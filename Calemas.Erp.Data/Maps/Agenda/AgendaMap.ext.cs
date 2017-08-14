using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public class AgendaMap : AgendaMapBase
    {
        public AgendaMap(EntityTypeBuilder<Agenda> type) : base(type)
        {

        }

        protected override void CustomConfig(EntityTypeBuilder<Agenda> type)
        {

        }

    }
}