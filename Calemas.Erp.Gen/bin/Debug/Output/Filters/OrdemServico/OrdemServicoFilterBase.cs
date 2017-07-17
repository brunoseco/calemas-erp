using Common.Domain.Base;
using System;

namespace calemas.erp.Domain.Filter
{
    public class OrdemServicoFilterBase : FilterBase
    {

        public int OrdemServicoId { get; set;} 
        public string Protoco { get; set;} 
        public int ResponsavelId { get; set;} 
        public int ClienteId { get; set;} 
        public int PrioridadeId { get; set;} 
        public int SetorId { get; set;} 
        public int TipoOrdemServicoId { get; set;} 
        public int AgendaId { get; set;} 
        public int StatusOrdemServicoId { get; set;} 
        public DateTime DataOcorrenciaStart { get; set;} 
        public DateTime DataOcorrenciaEnd { get; set;} 
        public DateTime DataOcorrencia { get; set;} 
        public DateTime DataSituacaoStart { get; set;} 
        public DateTime DataSituacaoEnd { get; set;} 
        public DateTime DataSituacao { get; set;} 
        public string Observacao { get; set;} 
        public string Descricao { get; set;} 
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
