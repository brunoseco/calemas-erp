using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class OrdemServicoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<OrdemServico> type);

        public OrdemServicoMapBase(EntityTypeBuilder<OrdemServico> type)
        {
            
            type.ToTable("OrdemServico");
            type.Property(t => t.OrdemServicoId).HasColumnName("Id");
           

            type.Property(t => t.Protoco).HasColumnName("Protoco");
            type.Property(t => t.ClienteId).HasColumnName("ClienteId");
            type.Property(t => t.PrioridadeId).HasColumnName("PrioridadeId");
            type.Property(t => t.SetorId).HasColumnName("SetorId");
            type.Property(t => t.TipoOrdemServicoId).HasColumnName("TipoOrdemServicoId");
            type.Property(t => t.AgendaId).HasColumnName("AgendaId");
            type.Property(t => t.StatusOrdemServicoId).HasColumnName("StatusOrdemServicoId");
            type.Property(t => t.DataSituacao).HasColumnName("DataSituacao");
            type.Property(t => t.Observacao).HasColumnName("Observacao");
            type.Property(t => t.Descricao).HasColumnName("Descricao");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.OrdemServicoId, }); 

			CustomConfig(type);
        }
		
    }
}