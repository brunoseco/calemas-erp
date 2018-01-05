using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class StatusClienteBase : DomainBaseWithUserCreate
    {
        public StatusClienteBase()
        {

        }
        public StatusClienteBase(int statusclienteid, string nome, bool ativo)
        {
            this.StatusClienteId = statusclienteid;
            this.Nome = nome;
            this.Ativo = ativo;

        }

        public virtual int StatusClienteId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual bool Ativo { get; protected set; }


public class StatusClienteFactoryBase
        {
            public virtual StatusCliente GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new StatusCliente(data.StatusClienteId,
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
