using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class SolicitacaoEstoqueMovimentacaoFilterBase : FilterBase
    {

        public virtual int SolicitacaoEstoqueMovimentacaoId { get; set;} 
        public virtual int EstoqueId { get; set;} 
        public virtual bool? Entrada { get; set;} 
        public virtual string Descricao { get; set;} 
        public virtual int SolicitanteId { get; set;} 
        public virtual DateTime DataSolicitacaoStart { get; set;} 
        public virtual DateTime DataSolicitacaoEnd { get; set;} 
        public virtual DateTime DataSolicitacao { get; set;} 
        public virtual DateTime DataPrevistaStart { get; set;} 
        public virtual DateTime DataPrevistaEnd { get; set;} 
        public virtual DateTime DataPrevista { get; set;} 
        public virtual int StatusSolicitacaoEstoqueMovimentacaoId { get; set;} 
        public virtual decimal Quantidade { get; set;} 
        public virtual int UserCreateId { get; set;} 
        public virtual DateTime UserCreateDateStart { get; set;} 
        public virtual DateTime UserCreateDateEnd { get; set;} 
        public virtual DateTime UserCreateDate { get; set;} 
        public virtual int? UserAlterId { get; set;} 
        public virtual DateTime? UserAlterDateStart { get; set;} 
        public virtual DateTime? UserAlterDateEnd { get; set;} 
        public virtual DateTime? UserAlterDate { get; set;} 


    }
}
