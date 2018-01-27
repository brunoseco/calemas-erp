using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class EstoqueMovimentacaoDto  : DtoBase
	{
	
        

        public virtual int EstoqueMovimentacaoId {get; set;}

        

        public virtual int EstoqueId {get; set;}

        [Required(ErrorMessage="EstoqueMovimentacao - Campo Entrada é Obrigatório")]
        public virtual bool Entrada {get; set;}

        [Required(ErrorMessage="EstoqueMovimentacao - Campo Descricao é Obrigatório")]
        [MaxLength(500, ErrorMessage = "EstoqueMovimentacao - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="EstoqueMovimentacao - Campo Quantidade é Obrigatório")]
        public virtual decimal Quantidade {get; set;}

        

        public virtual int ResponsavelId {get; set;}

        

        public virtual int? EstoqueMovimentacaoColaboradorId {get; set;}


		
	}
}