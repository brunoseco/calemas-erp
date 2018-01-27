using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class MotivoEstoqueMovimentacaoBase : DomainBase
    {
        public MotivoEstoqueMovimentacaoBase()
        {

        }
        public MotivoEstoqueMovimentacaoBase(int motivoestoquemovimentacaoid, string nome)
        {
            this.MotivoEstoqueMovimentacaoId = motivoestoquemovimentacaoid;
            this.Nome = nome;

        }

        public virtual int MotivoEstoqueMovimentacaoId { get; protected set; }
        public virtual string Nome { get; protected set; }


public class MotivoEstoqueMovimentacaoFactoryBase
        {
            public virtual MotivoEstoqueMovimentacao GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new MotivoEstoqueMovimentacao(data.MotivoEstoqueMovimentacaoId,
                                        data.Nome);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
