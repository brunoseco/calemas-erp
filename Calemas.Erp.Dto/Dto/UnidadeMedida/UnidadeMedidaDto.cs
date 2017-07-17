using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class UnidadeMedidaDto  : DtoBase
	{
	
        

        public virtual int UnidadeMedidaId {get; set;}

        [Required(ErrorMessage="UnidadeMedida - Campo Nome é Obrigatório")]
        [MaxLength(100, ErrorMessage = "UnidadeMedida - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}


		
	}
}