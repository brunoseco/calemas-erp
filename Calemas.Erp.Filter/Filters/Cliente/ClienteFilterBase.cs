using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class ClienteFilterBase : FilterBase
    {

        public int ClienteId { get; set;} 
        public int StatusClienteId { get; set;} 
        public int? CondominioId { get; set;} 
        public int ResponsavelId { get; set;} 


    }
}
