using Common.Domain.Base;
using Common.Domain.Model;
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


public class CategoriaEstoqueFactoryBase
        {
            public virtual CategoriaEstoque GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new CategoriaEstoque(data.CategoriaEstoqueId,
                                        data.Nome);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
