using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class OrdemServicoInteracaoBase : DomainBase
    {
        public OrdemServicoInteracaoBase()
        {

        }
        public OrdemServicoInteracaoBase(int ordemservicointeracaoid, int ordemservicoid, DateTime dataconclusao, string descricao, bool foipropriocliente, int tecnicoid, int statusordemservicointeracaoid)
        {
            this.OrdemServicoInteracaoId = ordemservicointeracaoid;
            this.OrdemServicoId = ordemservicoid;
            this.DataConclusao = dataconclusao;
            this.Descricao = descricao;
            this.FoiProprioCliente = foipropriocliente;
            this.TecnicoId = tecnicoid;
            this.StatusOrdemServicoInteracaoId = statusordemservicointeracaoid;

        }

        public virtual int OrdemServicoInteracaoId { get; protected set; }
        public virtual int OrdemServicoId { get; protected set; }
        public virtual DateTime DataConclusao { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Observacao { get; protected set; }
        public virtual bool FoiProprioCliente { get; protected set; }
        public virtual string NomeClienteResponsavel { get; protected set; }
        public virtual int TecnicoId { get; protected set; }
        public virtual int StatusOrdemServicoInteracaoId { get; protected set; }


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
