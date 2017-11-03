using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class InfraestruturaSiteMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<InfraestruturaSite> type);

        public InfraestruturaSiteMapBase(EntityTypeBuilder<InfraestruturaSite> type)
        {
            
            type.ToTable("InfraestruturaSite");
            type.Property(t => t.InfraestruturaSiteId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(50)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)");
            type.Property(t => t.Latitude).HasColumnName("Latitude").HasColumnType("varchar(50)");
            type.Property(t => t.Longitude).HasColumnName("Longitude").HasColumnType("varchar(50)");
            type.Property(t => t.Endpoint).HasColumnName("Endpoint").HasColumnType("varchar(100)");
            type.Property(t => t.Login).HasColumnName("Login").HasColumnType("varchar(50)");
            type.Property(t => t.Senha).HasColumnName("Senha").HasColumnType("varchar(50)");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.InfraestruturaSiteId, }); 

			CustomConfig(type);
        }
		
    }
}