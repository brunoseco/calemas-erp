using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class AgendaFilterBase : FilterBase
    {

        public int AgendaId { get; set;} 
        public string Nome { get; set;} 
        public string Descricao { get; set;} 
        public DateTime DataInicioStart { get; set;} 
        public DateTime DataInicioEnd { get; set;} 
        public DateTime DataInicio { get; set;} 
        public DateTime DataFimStart { get; set;} 
        public DateTime DataFimEnd { get; set;} 
        public DateTime DataFim { get; set;} 
        public int CorId { get; set;} 
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
