using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class NivelAcessoDto  : DtoBase
	{
	
        

        public virtual int NivelAcessoId {get; set;}

        [Required(ErrorMessage="NivelAcesso - Campo Nome é Obrigatório")]
        [MaxLength(100, ErrorMessage = "NivelAcesso - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}


		
	}
}