using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class CondominioBase : DomainBaseWithUserCreate
    {
        public CondominioBase()
        {

        }
        public CondominioBase(int condominioid, string nome, bool ativo)
        {
            this.CondominioId = condominioid;
            this.Nome = nome;
            this.Ativo = ativo;

        }

        public int CondominioId { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public bool Ativo { get; protected set; }


		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
