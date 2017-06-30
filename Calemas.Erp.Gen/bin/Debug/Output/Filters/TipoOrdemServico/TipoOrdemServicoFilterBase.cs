using Common.Domain.Base;
using System;

namespace calemas.erp.Domain.Filter
{
    public class TipoOrdemServicoFilterBase : FilterBase
    {

        public int TipoOrdemServicoId { get; set;} 
        public string Nome { get; set;} 
        public string Descricao { get; set;} 
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
