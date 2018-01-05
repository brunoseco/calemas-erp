using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class TipoPlanoContaBase : DomainBase
    {
        public TipoPlanoContaBase()
        {

        }
        public TipoPlanoContaBase(int tipoplanocontaid, string nome)
        {
            this.TipoPlanoContaId = tipoplanocontaid;
            this.Nome = nome;

        }

        public virtual int TipoPlanoContaId { get; protected set; }
        public virtual string Nome { get; protected set; }


public class TipoPlanoContaFactoryBase
        {
            public virtual TipoPlanoConta GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new TipoPlanoConta(data.TipoPlanoContaId,
                                        data.Nome);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
