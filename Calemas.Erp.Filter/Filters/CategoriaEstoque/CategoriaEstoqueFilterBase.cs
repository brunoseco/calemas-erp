using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class CategoriaEstoqueFilterBase : FilterBase
    {

        public virtual int CategoriaEstoqueId { get; set;} 
        public virtual string Nome { get; set;} 


    }
}
