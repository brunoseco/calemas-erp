using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class OrdemServicoInteracaoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<OrdemServicoInteracao> type);

        public OrdemServicoInteracaoMapBase(EntityTypeBuilder<OrdemServicoInteracao> type)
        {
            
            type.ToTable("OrdemServicoInteracao");
            type.Property(t => t.OrdemServicoInteracaoId).HasColumnName("Id");
           

            type.Property(t => t.OrdemServicoId).HasColumnName("OrdemServicoId");
            type.Property(t => t.DataConclusao).HasColumnName("DataConclusao");
            type.Property(t => t.Descricao).HasColumnName("Descricao");
            type.Property(t => t.Observacao).HasColumnName("Observacao");
            type.Property(t => t.FoiProprioCliente).HasColumnName("FoiProprioCliente");
            type.Property(t => t.NomeClienteResponsavel).HasColumnName("NomeClienteResponsavel");
            type.Property(t => t.TecnicoId).HasColumnName("TecnicoId");
            type.Property(t => t.StatusOrdemServicoInteracaoId).HasColumnName("StatusOrdemServicoInteracaoId");


            type.HasKey(d => new { d.OrdemServicoInteracaoId, }); 

			CustomConfig(type);
        }
		
    }
}