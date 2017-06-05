using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class CursoFilterBase : FilterBase
    {

        public int CursoId { get; set;} 
        public int IdiomaId { get; set;} 
        public string Nome { get; set;} 
        public bool? Sistema { get; set;} 
        public bool? Ativo { get; set;} 
        public int Ordem { get; set;} 


    }
}
