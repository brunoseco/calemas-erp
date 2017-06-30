using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Data.Map
{
    public abstract class PessoaMapBase 
    {
        protected abstract void CustomConfig(EntityTypeBuilder<Pessoa> type);

        public PessoaMapBase(EntityTypeBuilder<Pessoa> type)
        {
            
            type.ToTable("Pessoa");
            type.Property(t => t.PessoaId).HasColumnName("Id");
           

            type.Property(t => t.CPF_CNPJ).HasColumnName("CPF_CNPJ");
            type.Property(t => t.RG_IE).HasColumnName("RG_IE");
            type.Property(t => t.Nome).HasColumnName("Nome");
            type.Property(t => t.Apelido).HasColumnName("Apelido");
            type.Property(t => t.Email).HasColumnName("Email");
            type.Property(t => t.Telefone).HasColumnName("Telefone");
            type.Property(t => t.Celular).HasColumnName("Celular");
            type.Property(t => t.Comercial).HasColumnName("Comercial");
            type.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            type.Property(t => t.EstadoCivilId).HasColumnName("EstadoCivilId");
            type.Property(t => t.Sexo).HasColumnName("Sexo");
            type.Property(t => t.Juridica).HasColumnName("Juridica");
            type.Property(t => t.EnderecoId).HasColumnName("EnderecoId");
            type.Property(t => t.UserCreateId).HasColumnName("UserCreateId");
            type.Property(t => t.UserCreateDate).HasColumnName("UserCreateDate");
            type.Property(t => t.UserAlterId).HasColumnName("UserAlterId");
            type.Property(t => t.UserAlterDate).HasColumnName("UserAlterDate");


            type.HasKey(d => new { d.PessoaId, }); 

			CustomConfig(type);
        }
		
    }
}