using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class EnderecoMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Endereco> type);

        public EnderecoMapBase(EntityTypeBuilder<Endereco> type)
        {
            
            type.ToTable("Endereco");
            type.Property(t => t.EnderecoId).HasColumnName("Id");
           

            type.Property(t => t.CEP).HasColumnName("CEP").HasColumnType("varchar(9)");
            type.Property(t => t.Rua).HasColumnName("Rua").HasColumnType("varchar(150)");
            type.Property(t => t.Numero).HasColumnName("Numero").HasColumnType("varchar(150)");
            type.Property(t => t.Complemento).HasColumnName("Complemento").HasColumnType("varchar(150)");
            type.Property(t => t.Bairro).HasColumnName("Bairro").HasColumnType("varchar(150)");
            type.Property(t => t.Cidade).HasColumnName("Cidade").HasColumnType("varchar(150)");
            type.Property(t => t.UF).HasColumnName("UF").HasColumnType("varchar(2)");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.EnderecoId, }); 

			CustomConfig(type);
        }
		
    }
}