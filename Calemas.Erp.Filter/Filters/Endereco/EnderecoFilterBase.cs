using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class EnderecoFilterBase : FilterBase
    {

        public int EnderecoId { get; set;} 
        public string CEP { get; set;} 
        public string Rua { get; set;} 
        public string Numero { get; set;} 
        public string Complemento { get; set;} 
        public string PontoReferencia { get; set;} 
        public string Cidade { get; set;} 
        public int? EstadoId { get; set;} 
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
