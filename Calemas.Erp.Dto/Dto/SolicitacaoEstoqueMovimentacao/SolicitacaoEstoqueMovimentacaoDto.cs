using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class SolicitacaoEstoqueMovimentacaoDto  : DtoBase
	{
	
        

        public virtual int SolicitacaoEstoqueMovimentacaoId {get; set;}

        

        public virtual int EstoqueId {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoqueMovimentacao - Campo Entrada é Obrigatório")]

        public virtual bool Entrada {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoqueMovimentacao - Campo Descricao é Obrigatório")]
        [MaxLength(500, ErrorMessage = "SolicitacaoEstoqueMovimentacao - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}

        

        public virtual int SolicitanteId {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoqueMovimentacao - Campo DataSolicitacao é Obrigatório")]

        public virtual DateTime DataSolicitacao {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoqueMovimentacao - Campo DataPrevista é Obrigatório")]

        public virtual DateTime DataPrevista {get; set;}

        

        public virtual int StatusSolicitacaoEstoqueMovimentacaoId {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoqueMovimentacao - Campo Quantidade é Obrigatório")]

        public virtual decimal Quantidade {get; set;}


		
	}
}