using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class PlanoContaFilterBase : FilterBase
    {

        public int PlanoContaId { get; set;} 
        public string Nome { get; set;} 
        public string Descricao { get; set;} 
        public int TipoPlanoContaId { get; set;} 


    }
}
