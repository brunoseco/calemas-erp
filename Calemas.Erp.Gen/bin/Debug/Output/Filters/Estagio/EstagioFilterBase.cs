using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class EstagioFilterBase : FilterBase
    {

        public int EstagioId { get; set;} 
        public string Nome { get; set;} 
        public int NivelId { get; set;} 
        public string Sigla { get; set;} 
        public decimal MediaAprovacao { get; set;} 
        public int PublicoAlvoMinimo { get; set;} 
        public int PublicoAlvoMaximo { get; set;} 
        public int VagasMinima { get; set;} 
        public int VagasMaxima { get; set;} 
        public decimal Duracao { get; set;} 
        public bool? Ativo { get; set;} 
        public bool? Inicial { get; set;} 
        public int? Ordem { get; set;} 
        public bool? AvaliacaoPorConceito { get; set;} 
        public decimal FatorAvaliacao { get; set;} 
        public bool? PodeCriarTurma { get; set;} 
        public int? MesmoMaterialDidaticoEstagioId { get; set;} 


    }
}
