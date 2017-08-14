using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class AgendaBase : DomainBaseWithUserCreate
    {
        public AgendaBase()
        {

        }
        public AgendaBase(int agendaid, string nome, DateTime datainicio, DateTime datafim, int corid)
        {
            this.AgendaId = agendaid;
            this.Nome = nome;
            this.DataInicio = datainicio;
            this.DataFim = datafim;
            this.CorId = corid;

        }

        public int AgendaId { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public DateTime DataInicio { get; protected set; }
        public DateTime DataFim { get; protected set; }
        public int CorId { get; protected set; }


		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
