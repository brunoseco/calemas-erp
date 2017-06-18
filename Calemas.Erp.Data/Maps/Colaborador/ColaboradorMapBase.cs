using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class ColaboradorMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Colaborador> type);

        public ColaboradorMapBase(EntityTypeBuilder<Colaborador> type)
        {
            
            type.ToTable("Colaborador");
            type.Property(t => t.ColaboradorId).HasColumnName("Id");
           

            type.Property(t => t.Account).HasColumnName("Account");
            type.Property(t => t.Password).HasColumnName("Password");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.ColaboradorId, }); 

			CustomConfig(type);
        }
		
    }
}