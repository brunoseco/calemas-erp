using Common.Domain.Base;
using Common.Domain.Model;
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

        public virtual int StatusOrdemServicoId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual bool Ativo { get; protected set; }


public class StatusOrdemServicoFactoryBase
        {
            public virtual StatusOrdemServico GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new StatusOrdemServico(data.StatusOrdemServicoId,
                                        data.Nome,
                                        data.Ativo);

                construction.SetarDescricao(data.Descricao);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
