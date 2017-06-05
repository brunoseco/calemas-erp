using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class EmpresaParceiraFilterBase : FilterBase
    {

        public int EmpresaParceiraId { get; set;} 
        public int TipoParceriaId { get; set;} 
        public string ArquivoAceiteParceria { get; set;} 
        public int? DivulgadorId { get; set;} 
        public string Contato { get; set;} 
        public string Observacoes { get; set;} 
        public string ObservacoesCancelamento { get; set;} 
        public int? CategoriaEmpresaParceiraId { get; set;} 
        public int? QuantidadeFuncionarios { get; set;} 
        public int Status { get; set;} 
        public int UserCreateId { get; set;} 
        public DateTime UserCreateDateStart { get; set;} 
        public DateTime UserCreateDateEnd { get; set;} 
        public DateTime UserCreateDate { get; set;} 
        public int? UserAlterId { get; set;} 
        public DateTime? UserAlterDateStart { get; set;} 
        public DateTime? UserAlterDateEnd { get; set;} 
        public DateTime? UserAlterDate { get; set;} 


    }
}
