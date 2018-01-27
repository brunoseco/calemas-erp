using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class EstoqueMovimentacaoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<EstoqueMovimentacao> type);

        public EstoqueMovimentacaoMapBase(EntityTypeBuilder<EstoqueMovimentacao> type)
        {
            
            type.ToTable("EstoqueMovimentacao");
            type.Property(t => t.EstoqueMovimentacaoId).HasColumnName("Id");
           

            type.Property(t => t.EstoqueId).HasColumnName("EstoqueId");
            type.Property(t => t.Entrada).HasColumnName("Entrada");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)");
            type.Property(t => t.Quantidade).HasColumnName("Quantidade");
            type.Property(t => t.MotivoEstoqueMovimentacaoId).HasColumnName("MotivoEstoqueMovimentacaoId");
            type.Property(t => t.ResponsavelId).HasColumnName("ResponsavelId");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.EstoqueMovimentacaoId, }); 

			CustomConfig(type);
        }
		
    }
}