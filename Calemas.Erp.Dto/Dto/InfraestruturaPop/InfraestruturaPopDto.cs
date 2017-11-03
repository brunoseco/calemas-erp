using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class InfraestruturaPopDto  : DtoBase
	{
	
        

        public virtual int InfraestruturaPopId {get; set;}

        [Required(ErrorMessage="InfraestruturaPop - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "InfraestruturaPop - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        

        public virtual string Latitude {get; set;}

        

        public virtual string Longitude {get; set;}

        

        public virtual int InfraestruturaSiteId {get; set;}


		
	}
}