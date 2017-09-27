using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class StatusOrdemServicoDto  : DtoBase
	{
	
        

        public virtual int StatusOrdemServicoId {get; set;}

        [Required(ErrorMessage="StatusOrdemServico - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusOrdemServico - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="StatusOrdemServico - Campo Ativo é Obrigatório")]

        public virtual bool Ativo {get; set;}


		
	}
}