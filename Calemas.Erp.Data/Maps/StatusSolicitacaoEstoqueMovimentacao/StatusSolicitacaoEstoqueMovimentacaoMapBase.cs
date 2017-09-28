using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class StatusSolicitacaoEstoqueMovimentacaoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusSolicitacaoEstoqueMovimentacao> type);

        public StatusSolicitacaoEstoqueMovimentacaoMapBase(EntityTypeBuilder<StatusSolicitacaoEstoqueMovimentacao> type)
        {
            
            type.ToTable("StatusSolicitacaoEstoqueMovimentacao");
            type.Property(t => t.StatusSolicitacaoEstoqueMovimentacaoId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");


            type.HasKey(d => new { d.StatusSolicitacaoEstoqueMovimentacaoId, }); 

			CustomConfig(type);
        }
		
    }
}