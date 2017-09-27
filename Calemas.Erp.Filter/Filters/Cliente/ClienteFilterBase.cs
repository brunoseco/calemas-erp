using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class ClienteFilterBase : FilterBase
    {

        public virtual int ClienteId { get; set;} 
        public virtual int StatusClienteId { get; set;} 
        public virtual int? CondominioId { get; set;} 
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
