using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class SolicitacaoEstoqueMovimentacaoDto  : DtoBase
	{
	
        

        public virtual int SolicitacaoEstoqueMovimentacaoId {get; set;}

        

        public virtual int SolicitacaoEstoqueId {get; set;}

        

        public virtual int EstoqueId {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoqueMovimentacao - Campo Entrada é Obrigatório")]
        public virtual bool Entrada {get; set;}

        [Required(ErrorMessage="SolicitacaoEstoqueMovimentacao - Campo Quantidade é Obrigatório")]
        public virtual decimal Quantidade {get; set;}


		
	}
}