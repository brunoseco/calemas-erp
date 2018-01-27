using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class EstoqueMovimentacaoColaboradorDto  : DtoBase
	{
	
        

        public virtual int EstoqueMovimentacaoColaboradorId {get; set;}

        

        public virtual int ColaboradorId {get; set;}

        [Required(ErrorMessage="EstoqueMovimentacaoColaborador - Campo Entrada é Obrigatório")]
        public virtual bool Entrada {get; set;}

        

        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="EstoqueMovimentacaoColaborador - Campo Quantidade é Obrigatório")]
        public virtual decimal Quantidade {get; set;}


		
	}
}