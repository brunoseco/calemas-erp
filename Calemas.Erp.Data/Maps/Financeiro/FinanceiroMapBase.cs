using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class FinanceiroMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Financeiro> type);

        public FinanceiroMapBase(EntityTypeBuilder<Financeiro> type)
        {
            
            type.ToTable("Financeiro");
            type.Property(t => t.FinanceiroId).HasColumnName("Id");
           

            type.Property(t => t.DataVencimento).HasColumnName("DataVencimento");
            type.Property(t => t.Parcela).HasColumnName("Parcela");
            type.Property(t => t.PlanoContaId).HasColumnName("PlanoContaId");
            type.Property(t => t.ValorOriginal).HasColumnName("ValorOriginal");
            type.Property(t => t.ValorDesconto).HasColumnName("ValorDesconto");
            type.Property(t => t.ValorMultaJuros).HasColumnName("ValorMultaJuros");
            type.Property(t => t.ValorFinal).HasColumnName("ValorFinal");
            type.Property(t => t.PessoaId).HasColumnName("PessoaId");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(500)");
            type.Property(t => t.Baixado).HasColumnName("Baixado");
            type.Property(t => t.DataBaixa).HasColumnName("DataBaixa");
            type.Property(t => t.ValorDescontoAteVencimento).HasColumnName("ValorDescontoAteVencimento");
            type.Property(t => t.PercentualJuros).HasColumnName("PercentualJuros");
            type.Property(t => t.PercentualMulta).HasColumnName("PercentualMulta");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.FinanceiroId, }); 

			CustomConfig(type);
        }
		
    }
}