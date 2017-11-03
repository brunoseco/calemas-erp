using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class CorMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Cor> type);

        public CorMapBase(EntityTypeBuilder<Cor> type)
        {
            
            type.ToTable("Cor");
            type.Property(t => t.CorId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(50)");
            type.Property(t => t.Hash).HasColumnName("Hash").HasColumnType("varchar(7)");


            type.HasKey(d => new { d.CorId, }); 

			CustomConfig(type);
        }
		
    }
}