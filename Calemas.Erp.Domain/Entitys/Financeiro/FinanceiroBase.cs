using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class FinanceiroBase : DomainBaseWithUserCreate
    {
        public FinanceiroBase()
        {

        }
        public FinanceiroBase(int financeiroid, DateTime datavencimento, int parcela, int planocontaid, decimal valororiginal, decimal valordesconto, decimal valormultajuros, decimal valorfinal, int pessoaid, string descricao, bool baixado, decimal valordescontoatevencimento, decimal percentualjuros, decimal percentualmulta)
        {
            this.FinanceiroId = financeiroid;
            this.DataVencimento = datavencimento;
            this.Parcela = parcela;
            this.PlanoContaId = planocontaid;
            this.ValorOriginal = valororiginal;
            this.ValorDesconto = valordesconto;
            this.ValorMultaJuros = valormultajuros;
            this.ValorFinal = valorfinal;
            this.PessoaId = pessoaid;
            this.Descricao = descricao;
            this.Baixado = baixado;
            this.ValorDescontoAteVencimento = valordescontoatevencimento;
            this.PercentualJuros = percentualjuros;
            this.PercentualMulta = percentualmulta;

        }

        public int FinanceiroId { get; protected set; }
        public DateTime DataVencimento { get; protected set; }
        public int Parcela { get; protected set; }
        public int PlanoContaId { get; protected set; }
        public decimal ValorOriginal { get; protected set; }
        public decimal ValorDesconto { get; protected set; }
        public decimal ValorMultaJuros { get; protected set; }
        public decimal ValorFinal { get; protected set; }
        public int PessoaId { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Baixado { get; protected set; }
        public DateTime? DataBaixa { get; protected set; }
        public decimal ValorDescontoAteVencimento { get; protected set; }
        public decimal PercentualJuros { get; protected set; }
        public decimal PercentualMulta { get; protected set; }


		public virtual void SetarDataBaixa(DateTime? databaixa)
		{
			this.DataBaixa = databaixa;
		}


    }
}
