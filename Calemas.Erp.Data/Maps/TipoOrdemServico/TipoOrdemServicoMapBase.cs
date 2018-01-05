using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class TipoOrdemServicoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<TipoOrdemServico> type);

        public TipoOrdemServicoMapBase(EntityTypeBuilder<TipoOrdemServico> type)
        {
            
            type.ToTable("TipoOrdemServico");
            type.Property(t => t.TipoOrdemServicoId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(50)");
            type.Property(t => t.Descricao).HasColumnName("Descricao").HasColumnType("varchar(300)");
            type.Property(t => t.SetorId).HasColumnName("SetorId");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.TipoOrdemServicoId, }); 

			CustomConfig(type);
        }
		
    }
}