using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class StatusPagamentoFilterBase : FilterBase
    {

        public virtual int StatusPagamentoId { get; set;} 
        public virtual string Nome { get; set;} 


    }
}
