using System.ComponentModel.DataAnnotations;
using Common.Dto;
using System;

namespace Calemas.Erp.Dto
{
	public class FinanceiroDto  : DtoBase
	{
	
        

        public virtual int FinanceiroId {get; set;}

        [Required(ErrorMessage="Financeiro - Campo DataVencimento é Obrigatório")]
        public virtual DateTime DataVencimento {get; set;}

        [Required(ErrorMessage="Financeiro - Campo Parcela é Obrigatório")]
        public virtual int Parcela {get; set;}

        

        public virtual int PlanoContaId {get; set;}

        [Required(ErrorMessage="Financeiro - Campo ValorOriginal é Obrigatório")]
        public virtual decimal ValorOriginal {get; set;}

        [Required(ErrorMessage="Financeiro - Campo ValorDesconto é Obrigatório")]
        public virtual decimal ValorDesconto {get; set;}

        [Required(ErrorMessage="Financeiro - Campo ValorMultaJuros é Obrigatório")]
        public virtual decimal ValorMultaJuros {get; set;}

        [Required(ErrorMessage="Financeiro - Campo ValorFinal é Obrigatório")]
        public virtual decimal ValorFinal {get; set;}

        

        public virtual int PessoaId {get; set;}

        [Required(ErrorMessage="Financeiro - Campo Descricao é Obrigatório")]
        [MaxLength(500, ErrorMessage = "Financeiro - Quantidade de caracteres maior que o permitido para o campo Descricao")]
        public virtual string Descricao {get; set;}

        [Required(ErrorMessage="Financeiro - Campo Baixado é Obrigatório")]
        public virtual bool Baixado {get; set;}

        

        public virtual DateTime? DataBaixa {get; set;}

        [Required(ErrorMessage="Financeiro - Campo ValorDescontoAteVencimento é Obrigatório")]
        public virtual decimal ValorDescontoAteVencimento {get; set;}

        [Required(ErrorMessage="Financeiro - Campo PercentualJuros é Obrigatório")]
        public virtual decimal PercentualJuros {get; set;}

        [Required(ErrorMessage="Financeiro - Campo PercentualMulta é Obrigatório")]
        public virtual decimal PercentualMulta {get; set;}


		
	}
}