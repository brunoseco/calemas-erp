using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class TipoOrdemServicoBase : DomainBaseWithUserCreate
    {
        public TipoOrdemServicoBase()
        {

        }
        public TipoOrdemServicoBase(int tipoordemservicoid, string nome, int setorid, int prioridadeid, bool ativo)
        {
            this.TipoOrdemServicoId = tipoordemservicoid;
            this.Nome = nome;
            this.SetorId = setorid;
            this.PrioridadeId = prioridadeid;
            this.Ativo = ativo;

        }

        public virtual int TipoOrdemServicoId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual int SetorId { get; protected set; }
        public virtual int PrioridadeId { get; protected set; }
        public virtual bool Ativo { get; protected set; }


		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
