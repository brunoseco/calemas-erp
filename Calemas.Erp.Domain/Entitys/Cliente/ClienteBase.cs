using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class ClienteBase : DomainBase
    {
        public ClienteBase()
        {

        }
        public ClienteBase(int clienteid, int statusclienteid, int responsavelid)
        {
            this.ClienteId = clienteid;
            this.StatusClienteId = statusclienteid;
            this.ResponsavelId = responsavelid;

        }

        public virtual int ClienteId { get; protected set; }
        public virtual int StatusClienteId { get; protected set; }
        public virtual int? CondominioId { get; protected set; }
        public virtual int ResponsavelId { get; protected set; }


		public virtual void SetarCondominioId(int? condominioid)
		{
			this.CondominioId = condominioid;
		}


    }
}
