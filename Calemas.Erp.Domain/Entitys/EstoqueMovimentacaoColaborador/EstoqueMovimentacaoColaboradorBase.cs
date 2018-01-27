using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class EstoqueMovimentacaoColaboradorBase : DomainBase
    {
        public EstoqueMovimentacaoColaboradorBase()
        {

        }
        public EstoqueMovimentacaoColaboradorBase(int estoquemovimentacaocolaboradorid, int colaboradorid, int estoquemovimentacaoid, bool entrada, decimal quantidade)
        {
            this.EstoqueMovimentacaoColaboradorId = estoquemovimentacaocolaboradorid;
            this.ColaboradorId = colaboradorid;
            this.EstoqueMovimentacaoId = estoquemovimentacaoid;
            this.Entrada = entrada;
            this.Quantidade = quantidade;

        }

        public virtual int EstoqueMovimentacaoColaboradorId { get; protected set; }
        public virtual int ColaboradorId { get; protected set; }
        public virtual int EstoqueMovimentacaoId { get; protected set; }
        public virtual bool Entrada { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual decimal Quantidade { get; protected set; }


public class EstoqueMovimentacaoColaboradorFactoryBase
        {
            public virtual EstoqueMovimentacaoColaborador GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new EstoqueMovimentacaoColaborador(data.EstoqueMovimentacaoColaboradorId,
                                        data.ColaboradorId,
                                        data.EstoqueMovimentacaoId,
                                        data.Entrada,
                                        data.Quantidade);

                construction.SetarDescricao(data.Descricao);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}


    }
}
