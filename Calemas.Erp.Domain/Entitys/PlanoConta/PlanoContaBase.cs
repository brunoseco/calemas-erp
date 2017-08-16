using Common.Domain.Base;
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




    }
}
