using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class BancoDto  : DtoBase
	{
	
        

        public virtual int BancoId {get; set;}

        [Required(ErrorMessage="Banco - Campo Nome é Obrigatório")]
        [MaxLength(80, ErrorMessage = "Banco - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Numero {get; set;}

        

        public virtual string Digito {get; set;}

        [Required(ErrorMessage="Banco - Campo BoletoSemRegistro é Obrigatório")]
        public virtual bool BoletoSemRegistro {get; set;}

        [Required(ErrorMessage="Banco - Campo BoletoComRegistro é Obrigatório")]
        public virtual bool BoletoComRegistro {get; set;}

        [Required(ErrorMessage="Banco - Campo Ativo é Obrigatório")]
        public virtual bool Ativo {get; set;}


		
	}
}