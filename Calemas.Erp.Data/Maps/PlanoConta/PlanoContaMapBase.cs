using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class PlanoContaMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<PlanoConta> type);

        public PlanoContaMapBase(EntityTypeBuilder<PlanoConta> type)
        {
            
            type.ToTable("PlanoConta");
            type.Property(t => t.PlanoContaId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");
            type.Property(t => t.Descricao).HasColumnName("Descricao");
            type.Property(t => t.TipoPlanoContaId).HasColumnName("TipoPlanoContaId");


            type.HasKey(d => new { d.PlanoContaId, }); 

			CustomConfig(type);
        }
		
    }
}