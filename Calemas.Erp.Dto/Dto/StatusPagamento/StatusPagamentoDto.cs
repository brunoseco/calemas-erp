using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class StatusPagamentoDto  : DtoBase
	{
	
        

        public virtual int StatusPagamentoId {get; set;}

        [Required(ErrorMessage="StatusPagamento - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusPagamento - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}


		
	}
}