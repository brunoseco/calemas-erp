using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class OrdemServicoInteracaoBase : DomainBase
    {
        public OrdemServicoInteracaoBase()
        {

        }
        public OrdemServicoInteracaoBase(int ordemservicointeracaoid, int ordemservicoid, DateTime dataconclusao, string descricao, bool foipropriocliente, int tecnicoid, int statusordemservicoid, int statuspagamentoid)
        {
            this.OrdemServicoInteracaoId = ordemservicointeracaoid;
            this.OrdemServicoId = ordemservicoid;
            this.DataConclusao = dataconclusao;
            this.Descricao = descricao;
            this.FoiProprioCliente = foipropriocliente;
            this.TecnicoId = tecnicoid;
            this.StatusOrdemServicoId = statusordemservicoid;
            this.StatusPagamentoId = statuspagamentoid;

        }

        public virtual int OrdemServicoInteracaoId { get; protected set; }
        public virtual int OrdemServicoId { get; protected set; }
        public virtual DateTime DataConclusao { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Observacao { get; protected set; }
        public virtual bool FoiProprioCliente { get; protected set; }
        public virtual string NomeClienteResponsavel { get; protected set; }
        public virtual int TecnicoId { get; protected set; }
        public virtual int StatusOrdemServicoId { get; protected set; }
        public virtual int StatusPagamentoId { get; protected set; }


public class OrdemServicoInteracaoFactoryBase
        {
            public virtual OrdemServicoInteracao GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new OrdemServicoInteracao(data.OrdemServicoInteracaoId,
                                        data.OrdemServicoId,
                                        data.DataConclusao,
                                        data.Descricao,
                                        data.FoiProprioCliente,
                                        data.TecnicoId,
                                        data.StatusOrdemServicoId,
                                        data.StatusPagamentoId);

                construction.SetarObservacao(data.Observacao);
                construction.SetarNomeClienteResponsavel(data.NomeClienteResponsavel);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

		public virtual void SetarObservacao(string observacao)
		{
			this.Observacao = observacao;
		}
		public virtual void SetarNomeClienteResponsavel(string nomeclienteresponsavel)
		{
			this.NomeClienteResponsavel = nomeclienteresponsavel;
		}


    }
}
