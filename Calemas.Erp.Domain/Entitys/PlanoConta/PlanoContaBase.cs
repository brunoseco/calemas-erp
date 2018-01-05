using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class PlanoContaBase : DomainBase
    {
        public PlanoContaBase()
        {

        }
        public PlanoContaBase(int planocontaid, string nome, string descricao, int tipoplanocontaid)
        {
            this.PlanoContaId = planocontaid;
            this.Nome = nome;
            this.Descricao = descricao;
            this.TipoPlanoContaId = tipoplanocontaid;

        }

        public virtual int PlanoContaId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual int TipoPlanoContaId { get; protected set; }


public class PlanoContaFactoryBase
        {
            public virtual PlanoConta GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new PlanoConta(data.PlanoContaId,
                                        data.Nome,
                                        data.Descricao,
                                        data.TipoPlanoContaId);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
