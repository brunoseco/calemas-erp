using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class CorFilterBase : FilterBase
    {

        public int CorId { get; set;} 
        public string Nome { get; set;} 
        public string Hash { get; set;} 


    }
}
