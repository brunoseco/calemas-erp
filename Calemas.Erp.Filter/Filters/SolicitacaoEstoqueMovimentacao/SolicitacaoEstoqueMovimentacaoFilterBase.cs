using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class SolicitacaoEstoqueMovimentacaoFilterBase : FilterBase
    {

        public virtual int SolicitacaoEstoqueMovimentacaoId { get; set;} 
        public virtual int SolicitacaoEstoqueId { get; set;} 
        public virtual int EstoqueId { get; set;} 
        public virtual bool? Entrada { get; set;} 
        public virtual decimal Quantidade { get; set;} 


    }
}
