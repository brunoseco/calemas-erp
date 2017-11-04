using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class SolicitacaoEstoqueMovimentacaoBase : DomainBase
    {
        public SolicitacaoEstoqueMovimentacaoBase()
        {

        }
        public SolicitacaoEstoqueMovimentacaoBase(int solicitacaoestoquemovimentacaoid, int solicitacaoestoqueid, int estoqueid, bool entrada, decimal quantidade)
        {
            this.SolicitacaoEstoqueMovimentacaoId = solicitacaoestoquemovimentacaoid;
            this.SolicitacaoEstoqueId = solicitacaoestoqueid;
            this.EstoqueId = estoqueid;
            this.Entrada = entrada;
            this.Quantidade = quantidade;

        }

        public virtual int SolicitacaoEstoqueMovimentacaoId { get; protected set; }
        public virtual int SolicitacaoEstoqueId { get; protected set; }
        public virtual int EstoqueId { get; protected set; }
        public virtual bool Entrada { get; protected set; }
        public virtual decimal Quantidade { get; protected set; }




    }
}
