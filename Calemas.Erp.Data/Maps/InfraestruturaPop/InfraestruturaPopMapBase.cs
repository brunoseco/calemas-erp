using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class InfraestruturaPopMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<InfraestruturaPop> type);

        public InfraestruturaPopMapBase(EntityTypeBuilder<InfraestruturaPop> type)
        {
            
            type.ToTable("InfraestruturaPop");
            type.Property(t => t.InfraestruturaPopId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(50)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)");
            type.Property(t => t.Latitude).HasColumnName("Latitude").HasColumnType("varchar(50)");
            type.Property(t => t.Longitude).HasColumnName("Longitude").HasColumnType("varchar(50)");
            type.Property(t => t.InfraestruturaSiteId).HasColumnName("InfraestruturaSiteId");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.InfraestruturaPopId, }); 

			CustomConfig(type);
        }
		
    }
}