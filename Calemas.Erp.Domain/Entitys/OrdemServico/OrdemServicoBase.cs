using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class OrdemServicoBase : DomainBaseWithUserCreate
    {
        public OrdemServicoBase()
        {

        }
        public OrdemServicoBase(int ordemservicoid, string protoco, int responsavelid, int clienteid, int tipoordemservicoid, int agendaid, int statusordemservicoid, DateTime dataocorrencia, DateTime datasituacao)
        {
            this.OrdemServicoId = ordemservicoid;
            this.Protoco = protoco;
            this.ResponsavelId = responsavelid;
            this.ClienteId = clienteid;
            this.TipoOrdemServicoId = tipoordemservicoid;
            this.AgendaId = agendaid;
            this.StatusOrdemServicoId = statusordemservicoid;
            this.DataOcorrencia = dataocorrencia;
            this.DataSituacao = datasituacao;

        }

        public virtual int OrdemServicoId { get; protected set; }
        public virtual string Protoco { get; protected set; }
        public virtual int ResponsavelId { get; protected set; }
        public virtual int ClienteId { get; protected set; }
        public virtual int TipoOrdemServicoId { get; protected set; }
        public virtual int AgendaId { get; protected set; }
        public virtual int StatusOrdemServicoId { get; protected set; }
        public virtual int? StatusPagamentoId { get; protected set; }
        public virtual DateTime DataOcorrencia { get; protected set; }
        public virtual DateTime DataSituacao { get; protected set; }
        public virtual string Observacao { get; protected set; }
        public virtual string Descricao { get; protected set; }


public class OrdemServicoFactoryBase
        {
            public virtual OrdemServico GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new OrdemServico(data.OrdemServicoId,
                                        data.Protoco,
                                        data.ResponsavelId,
                                        data.ClienteId,
                                        data.TipoOrdemServicoId,
                                        data.AgendaId,
                                        data.StatusOrdemServicoId,
                                        data.DataOcorrencia,
                                        data.DataSituacao);

                construction.SetarStatusPagamentoId(data.StatusPagamentoId);
                construction.SetarObservacao(data.Observacao);
                construction.SetarDescricao(data.Descricao);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

		public virtual void SetarStatusPagamentoId(int? statuspagamentoid)
		{
			this.StatusPagamentoId = statuspagamentoid;
		}
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
