using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class SolicitacaoEstoqueMovimentacaoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<SolicitacaoEstoqueMovimentacao> type);

        public SolicitacaoEstoqueMovimentacaoMapBase(EntityTypeBuilder<SolicitacaoEstoqueMovimentacao> type)
        {
            
            type.ToTable("SolicitacaoEstoqueMovimentacao");
            type.Property(t => t.SolicitacaoEstoqueMovimentacaoId).HasColumnName("Id");
           

            type.Property(t => t.SolicitacaoEstoqueId).HasColumnName("SolicitacaoEstoqueId");
            type.Property(t => t.EstoqueId).HasColumnName("EstoqueId");
            type.Property(t => t.Entrada).HasColumnName("Entrada");
            type.Property(t => t.Quantidade).HasColumnName("Quantidade");


            type.HasKey(d => new { d.SolicitacaoEstoqueMovimentacaoId, }); 

			CustomConfig(type);
        }
		
    }
}