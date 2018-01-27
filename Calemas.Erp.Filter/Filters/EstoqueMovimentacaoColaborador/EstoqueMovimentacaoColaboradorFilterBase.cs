using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class EstoqueMovimentacaoColaboradorFilterBase : FilterBase
    {

        public virtual int EstoqueMovimentacaoColaboradorId { get; set;} 
        public virtual int ColaboradorId { get; set;} 
        public virtual bool? Entrada { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual decimal Quantidade { get; set;} 


    }
}
