using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class PessoaDto  : DtoBase
	{
	
        

        public virtual int PessoaId {get; set;}

        

        public virtual string CPF_CNPJ {get; set;}

        

        public virtual string RG_IE {get; set;}

        [Required(ErrorMessage="Pessoa - Campo Nome é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Pessoa - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        [Required(ErrorMessage="Pessoa - Campo Apelido é Obrigatório")]
        [MaxLength(150, ErrorMessage = "Pessoa - Quantidade de caracteres maior que o permitido para o campo Apelido")]
        public virtual string Apelido {get; set;}

        

        public virtual string Email {get; set;}

        

        public virtual string Telefone {get; set;}

        

        public virtual string Celular {get; set;}

        

        public virtual string Comercial {get; set;}

        

        public virtual DateTime? DataNascimento {get; set;}

        

        public virtual int? EstadoCivilId {get; set;}

        

        public virtual int? Sexo {get; set;}

        

        public virtual bool? Juridica {get; set;}

        

        public virtual int? EnderecoId {get; set;}


		
	}
}