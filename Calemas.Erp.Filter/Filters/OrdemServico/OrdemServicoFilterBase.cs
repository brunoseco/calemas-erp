using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Filter
{
    public class OrdemServicoFilterBase : FilterBase
    {

        public virtual int OrdemServicoId { get; set;} 
        public virtual string Protoco { get; set;} 
        public virtual int ResponsavelId { get; set;} 
        public virtual int ClienteId { get; set;} 
        public virtual int TipoOrdemServicoId { get; set;} 
        public virtual int AgendaId { get; set;} 
        public virtual int StatusOrdemServicoId { get; set;} 
        public virtual DateTime DataOcorrenciaStart { get; set;} 
        public virtual DateTime DataOcorrenciaEnd { get; set;} 
        public virtual DateTime DataOcorrencia { get; set;} 
        public virtual DateTime DataSituacaoStart { get; set;} 
        public virtual DateTime DataSituacaoEnd { get; set;} 
        public virtual DateTime DataSituacao { get; set;} 
        public virtual string Observacao { get; set;} 
        public virtual string Descricao { get; set;} 
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
