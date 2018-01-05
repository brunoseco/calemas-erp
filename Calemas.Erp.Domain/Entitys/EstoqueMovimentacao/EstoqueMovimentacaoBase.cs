using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class EstoqueMovimentacaoBase : DomainBaseWithUserCreate
    {
        public EstoqueMovimentacaoBase()
        {

        }
        public EstoqueMovimentacaoBase(int estoquemovimentacaoid, int estoqueid, bool entrada, string descricao, decimal quantidade, int responsavelid)
        {
            this.EstoqueMovimentacaoId = estoquemovimentacaoid;
            this.EstoqueId = estoqueid;
            this.Entrada = entrada;
            this.Descricao = descricao;
            this.Quantidade = quantidade;
            this.ResponsavelId = responsavelid;

        }

        public virtual int EstoqueMovimentacaoId { get; protected set; }
        public virtual int EstoqueId { get; protected set; }
        public virtual bool Entrada { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual decimal Quantidade { get; protected set; }
        public virtual int ResponsavelId { get; protected set; }


public class EstoqueMovimentacaoFactoryBase
        {
            public virtual EstoqueMovimentacao GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new EstoqueMovimentacao(data.EstoqueMovimentacaoId,
                                        data.EstoqueId,
                                        data.Entrada,
                                        data.Descricao,
                                        data.Quantidade,
                                        data.ResponsavelId);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
