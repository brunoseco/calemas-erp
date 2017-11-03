using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class CategoriaEstoqueMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<CategoriaEstoque> type);

        public CategoriaEstoqueMapBase(EntityTypeBuilder<CategoriaEstoque> type)
        {
            
            type.ToTable("CategoriaEstoque");
            type.Property(t => t.CategoriaEstoqueId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome").HasColumnType("varchar(100)");


            type.HasKey(d => new { d.CategoriaEstoqueId, }); 

			CustomConfig(type);
        }
		
    }
}