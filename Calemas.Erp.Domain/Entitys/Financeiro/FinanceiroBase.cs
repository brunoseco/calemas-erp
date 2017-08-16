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

        public virtual int FinanceiroId { get; protected set; }
        public virtual DateTime DataVencimento { get; protected set; }
        public virtual int Parcela { get; protected set; }
        public virtual int PlanoContaId { get; protected set; }
        public virtual decimal ValorOriginal { get; protected set; }
        public virtual decimal ValorDesconto { get; protected set; }
        public virtual decimal ValorMultaJuros { get; protected set; }
        public virtual decimal ValorFinal { get; protected set; }
        public virtual int PessoaId { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual bool Baixado { get; protected set; }
        public virtual DateTime? DataBaixa { get; protected set; }
        public virtual decimal ValorDescontoAteVencimento { get; protected set; }
        public virtual decimal PercentualJuros { get; protected set; }
        public virtual decimal PercentualMulta { get; protected set; }


		public virtual void SetarDataBaixa(DateTime? databaixa)
		{
			this.DataBaixa = databaixa;
		}


    }
}
