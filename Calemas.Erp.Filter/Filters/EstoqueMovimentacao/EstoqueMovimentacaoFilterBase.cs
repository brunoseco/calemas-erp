using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class EstoqueMovimentacaoFilterBase : FilterBase
    {

        public int EstoqueMovimentacaoId { get; set;} 
        public int EstoqueId { get; set;} 
        public bool? Entrada { get; set;} 
        public string Descricao { get; set;} 
        public decimal Quantidade { get; set;} 
        public int ResponsavelId { get; set;} 
        public int? UserCreateId { get; set;} 
        public DateTime UserCreateDateStart { get; set;} 
        public DateTime UserCreateDateEnd { get; set;} 
        public DateTime UserCreateDate { get; set;} 
        public int? UserAlterId { get; set;} 
        public DateTime? UserAlterDateStart { get; set;} 
        public DateTime? UserAlterDateEnd { get; set;} 
        public DateTime? UserAlterDate { get; set;} 


    }
}
