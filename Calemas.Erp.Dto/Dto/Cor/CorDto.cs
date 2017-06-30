using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class CorDto  : DtoBase
	{
	
        

        public virtual int CorId {get; set;}

        [Required(ErrorMessage="Cor - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Cor - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        [Required(ErrorMessage="Cor - Campo Hash é Obrigatório")]
        [MaxLength(7, ErrorMessage = "Cor - Quantidade de caracteres maior que o permitido para o campo Hash")]
        public virtual string Hash {get; set;}


		
	}
}