using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class UnidadeMedidaBase : DomainBase
    {
        public UnidadeMedidaBase()
        {

        }
        public UnidadeMedidaBase(int unidademedidaid, string nome)
        {
            this.UnidadeMedidaId = unidademedidaid;
            this.Nome = nome;

        }

        public int UnidadeMedidaId { get; protected set; }
        public string Nome { get; protected set; }




    }
}
