using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class MotivoEstoqueMovimentacaoFilterBase : FilterBase
    {

        public virtual int MotivoEstoqueMovimentacaoId { get; set;} 
        public virtual string Nome { get; set;} 


    }
}
