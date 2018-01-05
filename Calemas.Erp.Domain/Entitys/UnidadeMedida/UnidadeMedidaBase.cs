using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class UnidadeMedidaBase : DomainBase
    {
        public UnidadeMedidaBase()
        {

        }
        public UnidadeMedidaBase(int unidademedidaid, string nome)
        {
            this.UnidadeMedidaId = unidademedidaid;
            this.Nome = nome;

        }

        public virtual int UnidadeMedidaId { get; protected set; }
        public virtual string Nome { get; protected set; }


public class UnidadeMedidaFactoryBase
        {
            public virtual UnidadeMedida GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new UnidadeMedida(data.UnidadeMedidaId,
                                        data.Nome);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
