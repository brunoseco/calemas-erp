using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class PessoaFilterBase : FilterBase
    {

        public int PessoaId { get; set;} 
        public string CPF_CNPJ { get; set;} 
        public string RG_IE { get; set;} 
        public string Nome { get; set;} 
        public string Apelido { get; set;} 
        public string Email { get; set;} 
        public string Telefone { get; set;} 
        public string Celular { get; set;} 
        public string Comercial { get; set;} 
        public DateTime? DataNascimentoStart { get; set;} 
        public DateTime? DataNascimentoEnd { get; set;} 
        public DateTime? DataNascimento { get; set;} 
        public int? EstadoCivilId { get; set;} 
        public int? Sexo { get; set;} 
        public bool? Juridica { get; set;} 
        public int? EnderecoId { get; set;} 
        public int UserCreateId { get; set;} 
        public DateTime UserCreateDateStart { get; set;} 
        public DateTime UserCreateDateEnd { get; set;} 
        public DateTime UserCreateDate { get; set;} 
        public int? UserAlterId { get; set;} 
        public DateTime? UserAlterDateStart { get; set;} 
        public DateTime? UserAlterDateEnd { get; set;} 
        public DateTime? UserAlterDate { get; set;} 


    }
}
