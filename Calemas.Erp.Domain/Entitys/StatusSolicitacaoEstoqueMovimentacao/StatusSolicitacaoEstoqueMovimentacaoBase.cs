using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class StatusSolicitacaoEstoqueMovimentacaoBase : DomainBase
    {
        public StatusSolicitacaoEstoqueMovimentacaoBase()
        {

        }
        public StatusSolicitacaoEstoqueMovimentacaoBase(int statussolicitacaoestoquemovimentacaoid, string nome)
        {
            this.StatusSolicitacaoEstoqueMovimentacaoId = statussolicitacaoestoquemovimentacaoid;
            this.Nome = nome;

        }

        public virtual int StatusSolicitacaoEstoqueMovimentacaoId { get; protected set; }
        public virtual string Nome { get; protected set; }




    }
}
