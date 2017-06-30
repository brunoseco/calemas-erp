using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class OrdemServicoBase : DomainBaseWithUserCreate
    {
        public OrdemServicoBase()
        {

        }
        public OrdemServicoBase(int ordemservicoid, string protoco, int clienteid, int prioridadeid, int setorid, int tipoordemservicoid, int agendaid, int statusordemservicoid, DateTime datasituacao)
        {
            this.OrdemServicoId = ordemservicoid;
            this.Protoco = protoco;
            this.ClienteId = clienteid;
            this.PrioridadeId = prioridadeid;
            this.SetorId = setorid;
            this.TipoOrdemServicoId = tipoordemservicoid;
            this.AgendaId = agendaid;
            this.StatusOrdemServicoId = statusordemservicoid;
            this.DataSituacao = datasituacao;

        }

        public int OrdemServicoId { get; protected set; }
        public string Protoco { get; protected set; }
        public int ClienteId { get; protected set; }
        public int PrioridadeId { get; protected set; }
        public int SetorId { get; protected set; }
        public int TipoOrdemServicoId { get; protected set; }
        public int AgendaId { get; protected set; }
        public int StatusOrdemServicoId { get; protected set; }
        public DateTime DataSituacao { get; protected set; }
        public string Observacao { get; protected set; }
        public string Descricao { get; protected set; }


		public virtual void SetarObservacao(string observacao)
		{
			this.Observacao = observacao;
		}
		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
