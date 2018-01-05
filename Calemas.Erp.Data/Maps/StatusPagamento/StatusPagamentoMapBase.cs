using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class StatusPagamentoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusPagamento> type);

        public StatusPagamentoMapBase(EntityTypeBuilder<StatusPagamento> type)
        {
            
            type.ToTable("StatusPagamento");
            type.Property(t => t.StatusPagamentoId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(50)");


            type.HasKey(d => new { d.StatusPagamentoId, }); 

			CustomConfig(type);
        }
		
    }
}