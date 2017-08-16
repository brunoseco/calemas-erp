using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class PessoaFilterBase : FilterBase
    {

        public virtual int PessoaId { get; set;} 
        public virtual string CPF_CNPJ { get; set;} 
        public virtual string RG_IE { get; set;} 
        public virtual string Nome { get; set;} 
        public virtual string Apelido { get; set;} 
        public virtual string Email { get; set;} 
        public virtual string Telefone { get; set;} 
        public virtual string Celular { get; set;} 
        public virtual string Comercial { get; set;} 
        public virtual DateTime? DataNascimentoStart { get; set;} 
        public virtual DateTime? DataNascimentoEnd { get; set;} 
        public virtual DateTime? DataNascimento { get; set;} 
        public virtual int? EstadoCivilId { get; set;} 
        public virtual int? Sexo { get; set;} 
        public virtual bool? Juridica { get; set;} 
        public virtual int? EnderecoId { get; set;} 
        public virtual int UserCreateId { get; set;} 
        public virtual DateTime UserCreateDateStart { get; set;} 
        public virtual DateTime UserCreateDateEnd { get; set;} 
        public virtual DateTime UserCreateDate { get; set;} 
        public virtual int? UserAlterId { get; set;} 
        public virtual DateTime? UserAlterDateStart { get; set;} 
        public virtual DateTime? UserAlterDateEnd { get; set;} 
        public virtual DateTime? UserAlterDate { get; set;} 


    }
}
