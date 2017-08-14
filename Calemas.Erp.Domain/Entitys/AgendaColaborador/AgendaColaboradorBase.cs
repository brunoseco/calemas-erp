using Common.Domain.Base;
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

        public int AgendaId { get; protected set; }
        public int ColaboradorId { get; protected set; }




    }
}
