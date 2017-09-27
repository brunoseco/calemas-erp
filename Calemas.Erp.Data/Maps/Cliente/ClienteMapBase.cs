using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class ClienteMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Cliente> type);

        public ClienteMapBase(EntityTypeBuilder<Cliente> type)
        {
            
            type.ToTable("Cliente");
            type.Property(t => t.ClienteId).HasColumnName("Id");
           

            type.Property(t => t.StatusClienteId).HasColumnName("StatusClienteId");
            type.Property(t => t.CondominioId).HasColumnName("CondominioId");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.ClienteId, }); 

			CustomConfig(type);
        }
		
    }
}