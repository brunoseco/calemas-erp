using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class AgendaFilterBase : FilterBase
    {

        public virtual int AgendaId { get; set;} 
        public virtual string Nome { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual DateTime DataInicioStart { get; set;} 
        public virtual DateTime DataInicioEnd { get; set;} 
        public virtual DateTime DataInicio { get; set;} 
        public virtual DateTime DataFimStart { get; set;} 
        public virtual DateTime DataFimEnd { get; set;} 
        public virtual DateTime DataFim { get; set;} 
        public virtual int CorId { get; set;} 
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
