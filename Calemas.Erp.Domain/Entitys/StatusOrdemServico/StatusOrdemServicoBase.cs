using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class StatusOrdemServicoBase : DomainBaseWithUserCreate
    {
        public StatusOrdemServicoBase()
        {

        }
        public StatusOrdemServicoBase(int statusordemservicoid, string nome, bool ativo)
        {
            this.StatusOrdemServicoId = statusordemservicoid;
            this.Nome = nome;
            this.Ativo = ativo;

        }

        public int StatusOrdemServicoId { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Ativo { get; protected set; }


		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
