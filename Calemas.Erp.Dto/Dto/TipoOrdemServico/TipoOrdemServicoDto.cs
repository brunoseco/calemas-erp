using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class TipoOrdemServicoDto  : DtoBase
	{
	
        

        public virtual int TipoOrdemServicoId {get; set;}

        [Required(ErrorMessage="TipoOrdemServico - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "TipoOrdemServico - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}

        

        public virtual string Descricao {get; set;}

        

        public virtual int SetorId {get; set;}

        

        public virtual int PrioridadeId {get; set;}

        [Required(ErrorMessage="TipoOrdemServico - Campo Ativo é Obrigatório")]

        public virtual bool Ativo {get; set;}


		
	}
}