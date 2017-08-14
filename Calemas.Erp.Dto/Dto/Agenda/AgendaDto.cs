using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class AgendaDto  : DtoBase
	{
	
        

        public virtual int AgendaId {get; set;}

        [Required(ErrorMessage="Agenda - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "Agenda - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="Agenda - Campo DataInicio é Obrigatório")]
        public virtual DateTime DataInicio {get; set;}

        [Required(ErrorMessage="Agenda - Campo DataFim é Obrigatório")]
        public virtual DateTime DataFim {get; set;}

        

        public virtual int CorId {get; set;}


		
	}
}