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
           

            type.Property(t => t.EstoqueId).HasColumnName("EstoqueId");
            type.Property(t => t.Entrada).HasColumnName("Entrada");
            type.Property(t => t.Descricao).HasColumnName("Descricao");
            type.Property(t => t.SolicitanteId).HasColumnName("SolicitanteId");
            type.Property(t => t.DataSolicitacao).HasColumnName("DataSolicitacao");
            type.Property(t => t.DataPrevista).HasColumnName("DataPrevista");
            type.Property(t => t.StatusSolicitacaoEstoqueMovimentacaoId).HasColumnName("StatusSolicitacaoEstoqueMovimentacaoId");
            type.Property(t => t.Quantidade).HasColumnName("Quantidade");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.SolicitacaoEstoqueMovimentacaoId, }); 

			CustomConfig(type);
        }
		
    }
}