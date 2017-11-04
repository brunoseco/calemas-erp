using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class SolicitacaoEstoqueMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<SolicitacaoEstoque> type);

        public SolicitacaoEstoqueMapBase(EntityTypeBuilder<SolicitacaoEstoque> type)
        {
            
            type.ToTable("SolicitacaoEstoque");
            type.Property(t => t.SolicitacaoEstoqueId).HasColumnName("Id");
           

            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)");
            type.Property(t => t.SolicitanteId).HasColumnName("SolicitanteId");
            type.Property(t => t.DataSolicitacao).HasColumnName("DataSolicitacao");
            type.Property(t => t.DataPrevista).HasColumnName("DataPrevista");
            type.Property(t => t.StatusSolicitacaoEstoqueMovimentacaoId).HasColumnName("StatusSolicitacaoEstoqueMovimentacaoId");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.SolicitacaoEstoqueId, }); 

			CustomConfig(type);
        }
		
    }
}