using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class StatusClienteDto  : DtoBase
	{
	
        

        public virtual int StatusClienteId {get; set;}

        [Required(ErrorMessage="StatusCliente - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusCliente - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="StatusCliente - Campo Ativo é Obrigatório")]

        public virtual bool Ativo {get; set;}


		
	}
}