using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class NivelFilterBase : FilterBase
    {

        public int NivelId { get; set;} 
        public int CursoId { get; set;} 
        public string Nome { get; set;} 
        public int Ordem { get; set;} 
        public bool? Ativo { get; set;} 


    }
}
