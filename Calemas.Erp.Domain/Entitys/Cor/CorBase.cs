using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class CorBase : DomainBase
    {
        public CorBase()
        {

        }
        public CorBase(int corid, string nome, string hash)
        {
            this.CorId = corid;
            this.Nome = nome;
            this.Hash = hash;

        }

        public virtual int CorId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Hash { get; protected set; }


public class CorFactoryBase
        {
            public virtual Cor GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Cor(data.CorId,
                                        data.Nome,
                                        data.Hash);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
