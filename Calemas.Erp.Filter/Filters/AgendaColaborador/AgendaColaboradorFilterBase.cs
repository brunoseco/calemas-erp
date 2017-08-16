using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class AgendaColaboradorFilterBase : FilterBase
    {

        public virtual int AgendaId { get; set;} 
        public virtual int ColaboradorId { get; set;} 


    }
}
