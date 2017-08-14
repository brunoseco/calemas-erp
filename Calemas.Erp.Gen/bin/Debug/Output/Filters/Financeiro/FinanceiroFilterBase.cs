using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class FinanceiroFilterBase : FilterBase
    {

        public int FinanceiroId { get; set;} 
        public DateTime DataVencimentoStart { get; set;} 
        public DateTime DataVencimentoEnd { get; set;} 
        public DateTime DataVencimento { get; set;} 
        public int Parcela { get; set;} 
        public int PlanoContaId { get; set;} 
        public decimal ValorOriginal { get; set;} 
        public decimal ValorDesconto { get; set;} 
        public decimal ValorMultaJuros { get; set;} 
        public decimal ValorFinal { get; set;} 
        public int PessoaId { get; set;} 
        public string Descricao { get; set;} 
        public bool? Baixado { get; set;} 
        public DateTime? DataBaixaStart { get; set;} 
        public DateTime? DataBaixaEnd { get; set;} 
        public DateTime? DataBaixa { get; set;} 
        public decimal ValorDescontoAteVencimento { get; set;} 
        public decimal PercentualJuros { get; set;} 
        public decimal PercentualMulta { get; set;} 
        public int UserCreateId { get; set;} 
        public DateTime UserCreateDateStart { get; set;} 
        public DateTime UserCreateDateEnd { get; set;} 
        public DateTime UserCreateDate { get; set;} 
        public int? UserAlterId { get; set;} 
        public DateTime? UserAlterDateStart { get; set;} 
        public DateTime? UserAlterDateEnd { get; set;} 
        public DateTime? UserAlterDate { get; set;} 


    }
}
