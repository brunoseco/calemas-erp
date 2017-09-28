using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class EnderecoFilterBase : FilterBase
    {

        public virtual int EnderecoId { get; set;} 
        public virtual string CEP { get; set;} 
        public virtual string Rua { get; set;} 
        public virtual string Numero { get; set;} 
        public virtual string Complemento { get; set;} 
        public virtual string Bairro { get; set;} 
        public virtual string Cidade { get; set;} 
        public virtual string UF { get; set;} 
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
