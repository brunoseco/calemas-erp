using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class ColaboradorFilterBase : FilterBase
    {

        public virtual int ColaboradorId { get; set;} 
        public virtual string Account { get; set;} 
        public virtual string Password { get; set;} 
        public virtual bool? Ativo { get; set;} 
        public virtual int NivelAcessoId { get; set;} 
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
