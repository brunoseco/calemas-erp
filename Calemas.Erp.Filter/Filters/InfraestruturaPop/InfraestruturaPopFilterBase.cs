using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class InfraestruturaPopFilterBase : FilterBase
    {

        public virtual int InfraestruturaPopId { get; set;} 
        public virtual string Nome { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual string Latitude { get; set;} 
        public virtual string Longitude { get; set;} 
        public virtual int InfraestruturaSiteId { get; set;} 
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
