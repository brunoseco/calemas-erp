using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class TipoPlanoContaDto  : DtoBase
	{
	
        

        public virtual int TipoPlanoContaId {get; set;}

        [Required(ErrorMessage="TipoPlanoConta - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "TipoPlanoConta - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}


		
	}
}