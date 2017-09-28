using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class StatusSolicitacaoEstoqueMovimentacaoDto  : DtoBase
	{
	
        

        public virtual int StatusSolicitacaoEstoqueMovimentacaoId {get; set;}

        [Required(ErrorMessage="StatusSolicitacaoEstoqueMovimentacao - Campo Nome é Obrigatório")]
        [MaxLength(50, ErrorMessage = "StatusSolicitacaoEstoqueMovimentacao - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}


		
	}
}