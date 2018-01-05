using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class StatusPagamentoBase : DomainBase
    {
        public StatusPagamentoBase()
        {

        }
        public StatusPagamentoBase(int statuspagamentoid, string nome)
        {
            this.StatusPagamentoId = statuspagamentoid;
            this.Nome = nome;

        }

        public virtual int StatusPagamentoId { get; protected set; }
        public virtual string Nome { get; protected set; }


public class StatusPagamentoFactoryBase
        {
            public virtual StatusPagamento GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new StatusPagamento(data.StatusPagamentoId,
                                        data.Nome);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
