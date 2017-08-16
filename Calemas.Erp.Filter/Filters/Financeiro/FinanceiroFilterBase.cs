using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class FinanceiroFilterBase : FilterBase
    {

        public virtual int FinanceiroId { get; set;} 
        public virtual DateTime DataVencimentoStart { get; set;} 
        public virtual DateTime DataVencimentoEnd { get; set;} 
        public virtual DateTime DataVencimento { get; set;} 
        public virtual int Parcela { get; set;} 
        public virtual int PlanoContaId { get; set;} 
        public virtual decimal ValorOriginal { get; set;} 
        public virtual decimal ValorDesconto { get; set;} 
        public virtual decimal ValorMultaJuros { get; set;} 
        public virtual decimal ValorFinal { get; set;} 
        public virtual int PessoaId { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual bool? Baixado { get; set;} 
        public virtual DateTime? DataBaixaStart { get; set;} 
        public virtual DateTime? DataBaixaEnd { get; set;} 
        public virtual DateTime? DataBaixa { get; set;} 
        public virtual decimal ValorDescontoAteVencimento { get; set;} 
        public virtual decimal PercentualJuros { get; set;} 
        public virtual decimal PercentualMulta { get; set;} 
        public virtual int UserCreateId { get; set;} 
        public virtual DateTime UserCreateDateStart { get; set;} 
        public virtual DateTime UserCreateDateEnd { get; set;} 
        public virtual DateTime UserCreateDate { get; set;} 
        public virtual int? UserAlterId { get; set;} 
        public virtual DateTime? UserAlterDateStart { get; set;} 
        public virtual DateTime? UserAlterDateEnd { get; set;} 
        public virtual DateTime? UserAlterDate { get; set;} 


    }
}
