using Common.Domain.Base;
using System;

namespace calemas.erp.Domain.Filter
{
    public class CorFilterBase : FilterBase
    {

        public virtual int CorId { get; set;} 
        public virtual string Nome { get; set;} 
        public virtual string Hash { get; set;} 


    }
}
