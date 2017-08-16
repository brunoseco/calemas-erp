using Common.Domain.Base;
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


		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
