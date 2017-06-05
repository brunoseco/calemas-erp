using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class BancoFilterBase : FilterBase
    {

        public int BancoId { get; set;} 
        public string Nome { get; set;} 
        public string Numero { get; set;} 
        public string Digito { get; set;} 
        public bool? BoletoSemRegistro { get; set;} 
        public bool? BoletoComRegistro { get; set;} 
        public bool? Ativo { get; set;} 
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
