using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class MotivoEstoqueMovimentacaoDto  : DtoBase
	{
	
        

        public virtual int MotivoEstoqueMovimentacaoId {get; set;}

        [Required(ErrorMessage="MotivoEstoqueMovimentacao - Campo Nome é Obrigatório")]
        [MaxLength(500, ErrorMessage = "MotivoEstoqueMovimentacao - Quantidade de caracteres maior que o permitido para o campo Nome")]
        public virtual string Nome {get; set;}


		
	}
}