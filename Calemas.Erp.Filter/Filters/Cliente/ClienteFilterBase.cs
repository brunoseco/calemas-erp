using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class ClienteFilterBase : FilterBase
    {

        public virtual int ClienteId { get; set;} 
        public virtual int StatusClienteId { get; set;} 
        public virtual int? CondominioId { get; set;} 
        public virtual int ResponsavelId { get; set;} 


    }
}
