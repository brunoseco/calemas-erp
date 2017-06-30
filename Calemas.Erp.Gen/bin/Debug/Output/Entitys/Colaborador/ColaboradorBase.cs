using Common.Domain.Base;
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

        public int ColaboradorId { get; protected set; }
        public string Account { get; protected set; }
        public string Password { get; protected set; }
        public bool Ativo { get; protected set; }
        public int NivelAcessoId { get; protected set; }




    }
}
