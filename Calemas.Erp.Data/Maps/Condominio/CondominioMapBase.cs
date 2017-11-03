using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class CondominioMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Condominio> type);

        public CondominioMapBase(EntityTypeBuilder<Condominio> type)
        {
            
            type.ToTable("Condominio");
            type.Property(t => t.CondominioId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(500)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)");
            type.Property(t => t.Sigla).HasColumnName("Sigla").HasColumnType("varchar(10)");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.EnderecoId).HasColumnName("EnderecoId");
            type.Property(t => t.InfraestruturaPopId).HasColumnName("InfraestruturaPopId");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.CondominioId, }); 

			CustomConfig(type);
        }
		
    }
}