using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class OrdemServicoInteracaoFilterBase : FilterBase
    {

        public virtual int OrdemServicoInteracaoId { get; set;} 
        public virtual int OrdemServicoId { get; set;} 
        public virtual DateTime DataConclusaoStart { get; set;} 
        public virtual DateTime DataConclusaoEnd { get; set;} 
        public virtual DateTime DataConclusao { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual string Observacao { get; set;} 
        public virtual bool? FoiProprioCliente { get; set;} 
        public virtual string NomeClienteResponsavel { get; set;} 
        public virtual int TecnicoId { get; set;} 
        public virtual int StatusOrdemServicoId { get; set;} 
        public virtual int StatusPagamentoId { get; set;} 


    }
}
