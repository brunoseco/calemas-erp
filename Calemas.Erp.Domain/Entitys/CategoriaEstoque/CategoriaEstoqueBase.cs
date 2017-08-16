using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class CategoriaEstoqueBase : DomainBase
    {
        public CategoriaEstoqueBase()
        {

        }
        public CategoriaEstoqueBase(int categoriaestoqueid, string nome)
        {
            this.CategoriaEstoqueId = categoriaestoqueid;
            this.Nome = nome;

        }

        public virtual int CategoriaEstoqueId { get; protected set; }
        public virtual string Nome { get; protected set; }




    }
}
