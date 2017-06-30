using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class PrioridadeBase : DomainBaseWithUserCreate
    {
        public PrioridadeBase()
        {

        }
        public PrioridadeBase(int prioridadeid, string nome, string cor, bool ativo)
        {
            this.PrioridadeId = prioridadeid;
            this.Nome = nome;
            this.Cor = cor;
            this.Ativo = ativo;

        }

        public int PrioridadeId { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public string Cor { get; protected set; }
        public bool Ativo { get; protected set; }


		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
