using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class NivelAcessoBase : DomainBase
    {
        public NivelAcessoBase()
        {

        }
        public NivelAcessoBase(int nivelacessoid, string nome)
        {
            this.NivelAcessoId = nivelacessoid;
            this.Nome = nome;

        }

        public virtual int NivelAcessoId { get; protected set; }
        public virtual string Nome { get; protected set; }


public class NivelAcessoFactoryBase
        {
            public virtual NivelAcesso GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new NivelAcesso(data.NivelAcessoId,
                                        data.Nome);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
