using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class SetorMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Setor> type);

        public SetorMapBase(EntityTypeBuilder<Setor> type)
        {
            
            type.ToTable("Setor");
            type.Property(t => t.SetorId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");
            type.Property(t => t.Descricao).HasColumnName("Descricao");
            type.Property(t => t.Cor).HasColumnName("Cor");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.SetorId, }); 

			CustomConfig(type);
        }
		
    }
}