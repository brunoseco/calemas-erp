using Common.Domain.Base;
using Common.Domain.Model;
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

        public virtual int AgendaId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual DateTime DataInicio { get; protected set; }
        public virtual DateTime DataFim { get; protected set; }
        public virtual int CorId { get; protected set; }


public class AgendaFactoryBase
        {
            public virtual Agenda GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Agenda(data.AgendaId,
                                        data.Nome,
                                        data.DataInicio,
                                        data.DataFim,
                                        data.CorId);

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
