using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class ClienteBase : DomainBaseWithUserCreate
    {
        public ClienteBase()
        {

        }
        public ClienteBase(int clienteid, int statusclienteid)
        {
            this.ClienteId = clienteid;
            this.StatusClienteId = statusclienteid;

        }

        public virtual int ClienteId { get; protected set; }
        public virtual int StatusClienteId { get; protected set; }
        public virtual int? CondominioId { get; protected set; }


		public virtual void SetarCondominioId(int? condominioid)
		{
			this.CondominioId = condominioid;
		}


    }
}
