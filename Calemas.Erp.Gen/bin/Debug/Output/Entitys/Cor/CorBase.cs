using Common.Domain.Base;
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

        public int CorId { get; protected set; }
        public string Nome { get; protected set; }
        public string Hash { get; protected set; }




    }
}
