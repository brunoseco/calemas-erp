using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class OrdemServicoInteracaoFilterBase : FilterBase
    {

        public int OrdemServicoInteracaoId { get; set;} 
        public int OrdemServicoId { get; set;} 
        public DateTime DataConclusaoStart { get; set;} 
        public DateTime DataConclusaoEnd { get; set;} 
        public DateTime DataConclusao { get; set;} 
        public string Descricao { get; set;} 
        public string Observacao { get; set;} 
        public bool? FoiProprioCliente { get; set;} 
        public string NomeClienteResponsavel { get; set;} 
        public int TecnicoId { get; set;} 
        public int StatusOrdemServicoInteracaoId { get; set;} 


    }
}
