using Common.Domain.Base;
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

        public int NivelAcessoId { get; protected set; }
        public string Nome { get; protected set; }




    }
}
