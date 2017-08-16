using Common.Domain.Base;
using System;

namespace calemas.erp.Domain.Filter
{
    public class CategoriaEstoqueFilterBase : FilterBase
    {

        public virtual int CategoriaEstoqueId { get; set;} 
        public virtual string Nome { get; set;} 


    }
}
