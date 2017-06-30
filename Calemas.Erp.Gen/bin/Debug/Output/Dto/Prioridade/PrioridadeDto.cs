using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class PrioridadeDto  : DtoBase
	{
	
        

        public virtual int PrioridadeId {get; set;}

        [Required(ErrorMessage="Prioridade - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Prioridade - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="Prioridade - Campo Cor é Obrigatório")]
        [MaxLength(7, ErrorMessage = "Prioridade - Quantidade de caracteres maior que o permitido para o campo Cor")]
        public virtual string Cor {get; set;}

        [Required(ErrorMessage="Prioridade - Campo Ativo é Obrigatório")]
        public virtual bool Ativo {get; set;}


		
	}
}