using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class PlanoContaDto  : DtoBase
	{
	
        

        public virtual int PlanoContaId {get; set;}

        [Required(ErrorMessage="PlanoConta - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "PlanoConta - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        [Required(ErrorMessage="PlanoConta - Campo Descricao é Obrigatório")]
        [MaxLength(200, ErrorMessage = "PlanoConta - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}

        

        public virtual int TipoPlanoContaId {get; set;}


		
	}
}