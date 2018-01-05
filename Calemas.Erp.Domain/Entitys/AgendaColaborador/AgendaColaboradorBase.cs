using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class AgendaColaboradorBase : DomainBase
    {
        public AgendaColaboradorBase()
        {

        }
        public AgendaColaboradorBase(int agendaid, int colaboradorid)
        {
            this.AgendaId = agendaid;
            this.ColaboradorId = colaboradorid;

        }

        public virtual int AgendaId { get; protected set; }
        public virtual int ColaboradorId { get; protected set; }


public class AgendaColaboradorFactoryBase
        {
            public virtual AgendaColaborador GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new AgendaColaborador(data.AgendaId,
                                        data.ColaboradorId);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
