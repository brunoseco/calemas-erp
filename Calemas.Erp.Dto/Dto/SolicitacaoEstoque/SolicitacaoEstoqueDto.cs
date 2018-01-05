using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class SolicitacaoEstoqueDto  : DtoBase
	{
	
        

        public virtual int SolicitacaoEstoqueId {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoque - Campo Descricao é Obrigatório")]
        [MaxLength(500, ErrorMessage = "SolicitacaoEstoque - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}

        

        public virtual int SolicitanteId {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoque - Campo DataSolicitacao é Obrigatório")]
        public virtual DateTime DataSolicitacao {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoque - Campo DataPrevista é Obrigatório")]
        public virtual DateTime DataPrevista {get; set;}

        

        public virtual int StatusSolicitacaoEstoqueMovimentacaoId {get; set;}


		
	}
}