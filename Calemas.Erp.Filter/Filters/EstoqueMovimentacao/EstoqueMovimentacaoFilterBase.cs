using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class EstoqueMovimentacaoFilterBase : FilterBase
    {

        public virtual int EstoqueMovimentacaoId { get; set;} 
        public virtual int EstoqueId { get; set;} 
        public virtual bool? Entrada { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual decimal Quantidade { get; set;} 
        public virtual int ResponsavelId { get; set;} 
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
