using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class UnidadeMedidaMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<UnidadeMedida> type);

        public UnidadeMedidaMapBase(EntityTypeBuilder<UnidadeMedida> type)
        {
            
            type.ToTable("UnidadeMedida");
            type.Property(t => t.UnidadeMedidaId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");


            type.HasKey(d => new { d.UnidadeMedidaId, }); 

			CustomConfig(type);
        }
		
    }
}