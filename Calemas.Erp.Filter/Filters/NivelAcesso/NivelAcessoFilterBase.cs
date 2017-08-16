using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class NivelAcessoFilterBase : FilterBase
    {

        public virtual int NivelAcessoId { get; set;} 
        public virtual string Nome { get; set;} 


    }
}
