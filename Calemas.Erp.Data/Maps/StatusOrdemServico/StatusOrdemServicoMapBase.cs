using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class StatusOrdemServicoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<StatusOrdemServico> type);

        public StatusOrdemServicoMapBase(EntityTypeBuilder<StatusOrdemServico> type)
        {
            
            type.ToTable("StatusOrdemServico");
            type.Property(t => t.StatusOrdemServicoId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(50)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(100)");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.StatusOrdemServicoId, }); 

			CustomConfig(type);
        }
		
    }
}