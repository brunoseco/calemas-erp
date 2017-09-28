using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class EstoqueMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Estoque> type);

        public EstoqueMapBase(EntityTypeBuilder<Estoque> type)
        {
            
            type.ToTable("Estoque");
            type.Property(t => t.EstoqueId).HasColumnName("Id");
           

            type.Property(t => t.Nome).HasColumnName("Nome");
            type.Property(t => t.Descricao).HasColumnName("Descricao");
            type.Property(t => t.Modelo).HasColumnName("Modelo");
            type.Property(t => t.Fabricante).HasColumnName("Fabricante");
            type.Property(t => t.Referencia).HasColumnName("Referencia");
            type.Property(t => t.UnidadeMedidaId).HasColumnName("UnidadeMedidaId");
            type.Property(t => t.CategoriaEstoqueId).HasColumnName("CategoriaEstoqueId");
            type.Property(t => t.Observacao).HasColumnName("Observacao");
            type.Property(t => t.QuantidadeMinima).HasColumnName("QuantidadeMinima");
            type.Property(t => t.Quantidade).HasColumnName("Quantidade");
            type.Property(t => t.ValorVenda).HasColumnName("ValorVenda");
            type.Property(t => t.ValorCompra).HasColumnName("ValorCompra");
            type.Property(t => t.Ativo).HasColumnName("Ativo");
            type.Property(t => t.Localizacao).HasColumnName("Localizacao");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.EstoqueId, }); 

			CustomConfig(type);
        }
		
    }
}