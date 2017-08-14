using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class AgendaColaboradorMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<AgendaColaborador> type);

        public AgendaColaboradorMapBase(EntityTypeBuilder<AgendaColaborador> type)
        {
            
            type.ToTable("AgendaColaborador");
            type.Property(t => t.AgendaId).HasColumnName("AgendaId");
            type.Property(t => t.ColaboradorId).HasColumnName("ColaboradorId");
           



            type.HasKey(d => new { d.AgendaId,d.ColaboradorId, }); 

			CustomConfig(type);
        }
		
    }
}