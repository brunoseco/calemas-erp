using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class InfraestruturaSiteDto  : DtoBase
	{
	
        

        public virtual int InfraestruturaSiteId {get; set;}

        [Required(ErrorMessage="InfraestruturaSite - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "InfraestruturaSite - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        

        public virtual string Latitude {get; set;}

        

        public virtual string Longitude {get; set;}

        

        public virtual string Endpoint {get; set;}

        

        public virtual string Login {get; set;}

        

        public virtual string Senha {get; set;}


		
	}
}