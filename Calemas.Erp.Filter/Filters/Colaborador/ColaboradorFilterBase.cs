using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class ColaboradorFilterBase : FilterBase
    {

        public int ColaboradorId { get; set;} 
        public string Account { get; set;} 
        public string Password { get; set;} 
        public int UserCreateId { get; set;} 
        public DateTime UserCreateDateStart { get; set;} 
        public DateTime UserCreateDateEnd { get; set;} 
        public DateTime UserCreateDate { get; set;} 
        public int? UserAlterId { get; set;} 
        public DateTime? UserAlterDateStart { get; set;} 
        public DateTime? UserAlterDateEnd { get; set;} 
        public DateTime? UserAlterDate { get; set;} 


    }
}
