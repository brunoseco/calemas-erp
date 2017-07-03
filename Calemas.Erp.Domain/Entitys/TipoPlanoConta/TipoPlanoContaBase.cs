using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class TipoPlanoContaBase : DomainBase
    {
        public TipoPlanoContaBase()
        {

        }
        public TipoPlanoContaBase(int tipoplanocontaid, string nome)
        {
            this.TipoPlanoContaId = tipoplanocontaid;
            this.Nome = nome;

        }

        public int TipoPlanoContaId { get; protected set; }
        public string Nome { get; protected set; }




    }
}
