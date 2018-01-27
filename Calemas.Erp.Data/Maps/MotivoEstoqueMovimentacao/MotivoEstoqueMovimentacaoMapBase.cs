using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class MotivoEstoqueMovimentacaoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<MotivoEstoqueMovimentacao> type);

        public MotivoEstoqueMovimentacaoMapBase(EntityTypeBuilder<MotivoEstoqueMovimentacao> type)
        {
            
            type.ToTable("MotivoEstoqueMovimentacao");
            type.Property(t => t.MotivoEstoqueMovimentacaoId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(500)");


            type.HasKey(d => new { d.MotivoEstoqueMovimentacaoId, }); 

			CustomConfig(type);
        }
		
    }
}