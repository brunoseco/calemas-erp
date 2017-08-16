using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class PlanoContaFilterBase : FilterBase
    {

        public virtual int PlanoContaId { get; set;} 
        public virtual string Nome { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual int TipoPlanoContaId { get; set;} 


    }
}
