using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class ColaboradorBase : DomainBaseWithUserCreate
    {
        public ColaboradorBase()
        {

        }
        public ColaboradorBase(int colaboradorid, string account, string password)
        {
            this.ColaboradorId = colaboradorid;
            this.Account = account;
            this.Password = password;

        }

        public int ColaboradorId { get; protected set; }
        public string Account { get; protected set; }
        public string Password { get; protected set; }




    }
}
