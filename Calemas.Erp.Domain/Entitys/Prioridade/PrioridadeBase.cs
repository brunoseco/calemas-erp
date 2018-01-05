using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class PrioridadeBase : DomainBaseWithUserCreate
    {
        public PrioridadeBase()
        {

        }
        public PrioridadeBase(int prioridadeid, string nome, int corid, bool ativo)
        {
            this.PrioridadeId = prioridadeid;
            this.Nome = nome;
            this.CorId = corid;
            this.Ativo = ativo;

        }

        public virtual int PrioridadeId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual int CorId { get; protected set; }
        public virtual bool Ativo { get; protected set; }


public class PrioridadeFactoryBase
        {
            public virtual Prioridade GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Prioridade(data.PrioridadeId,
                                        data.Nome,
                                        data.CorId,
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
