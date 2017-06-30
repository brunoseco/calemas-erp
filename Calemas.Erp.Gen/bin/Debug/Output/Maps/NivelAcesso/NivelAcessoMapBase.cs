using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class NivelAcessoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<NivelAcesso> type);

        public NivelAcessoMapBase(EntityTypeBuilder<NivelAcesso> type)
        {
            
            type.ToTable("NivelAcesso");
            type.Property(t => t.NivelAcessoId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");


            type.HasKey(d => new { d.NivelAcessoId, }); 

			CustomConfig(type);
        }
		
    }
}