using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class TipoPlanoContaMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TipoPlanoConta> type);

        public TipoPlanoContaMapBase(EntityTypeBuilder<TipoPlanoConta> type)
        {
            
            type.ToTable("TipoPlanoConta");
            type.Property(t => t.TipoPlanoContaId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");


            type.HasKey(d => new { d.TipoPlanoContaId, }); 

			CustomConfig(type);
        }
		
    }
}