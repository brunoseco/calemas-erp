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

        public int PlanoContaId { get; protected set; }
        public string Nome { get; protected set; }
        public string Descricao { get; protected set; }
        public int TipoPlanoContaId { get; protected set; }




    }
}
