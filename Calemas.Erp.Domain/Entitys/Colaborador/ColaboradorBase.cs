using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class ColaboradorBase : DomainBaseWithUserCreate
    {
        public ColaboradorBase()
        {

        }
        public ColaboradorBase(int colaboradorid, string account, string password, bool ativo, int nivelacessoid)
        {
            this.ColaboradorId = colaboradorid;
            this.Account = account;
            this.Password = password;
            this.Ativo = ativo;
            this.NivelAcessoId = nivelacessoid;

        }

        public virtual int ColaboradorId { get; protected set; }
        public virtual string Account { get; protected set; }
        public virtual string Password { get; protected set; }
        public virtual bool Ativo { get; protected set; }
        public virtual int NivelAcessoId { get; protected set; }


public class ColaboradorFactoryBase
        {
            public virtual Colaborador GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Colaborador(data.ColaboradorId,
                                        data.Account,
                                        data.Password,
                                        data.Ativo,
                                        data.NivelAcessoId);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
