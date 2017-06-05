using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class IdiomaFilterBase : FilterBase
    {

        public int IdiomaId { get; set;} 
        public string Nome { get; set;} 
        public bool? Ativo { get; set;} 


    }
}
