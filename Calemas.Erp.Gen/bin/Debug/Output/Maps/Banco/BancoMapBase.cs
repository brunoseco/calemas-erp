using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class BancoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Banco> type);

        public BancoMapBase(EntityTypeBuilder<Banco> type)
        {
            
            type.ToTable("Banco");
            type.Property(t => t.BancoId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");
            type.Property(t => t.Numero).HasColumnName("Numero");
            type.Property(t => t.Digito).HasColumnName("Digito");
            type.Property(t => t.BoletoSemRegistro).HasColumnName("BoletoSemRegistro");
            type.Property(t => t.BoletoComRegistro).HasColumnName("BoletoComRegistro");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.BancoId, }); 

			CustomConfig(type);
        }
		
    }
}