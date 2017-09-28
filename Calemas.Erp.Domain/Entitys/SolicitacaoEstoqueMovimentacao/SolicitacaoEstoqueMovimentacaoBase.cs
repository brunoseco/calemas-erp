using Common.Domain.Base;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class SolicitacaoEstoqueMovimentacaoBase : DomainBaseWithUserCreate
    {
        public SolicitacaoEstoqueMovimentacaoBase()
        {

        }
        public SolicitacaoEstoqueMovimentacaoBase(int solicitacaoestoquemovimentacaoid, int estoqueid, bool entrada, string descricao, int solicitanteid, DateTime datasolicitacao, DateTime dataprevista, int statussolicitacaoestoquemovimentacaoid, decimal quantidade)
        {
            this.SolicitacaoEstoqueMovimentacaoId = solicitacaoestoquemovimentacaoid;
            this.EstoqueId = estoqueid;
            this.Entrada = entrada;
            this.Descricao = descricao;
            this.SolicitanteId = solicitanteid;
            this.DataSolicitacao = datasolicitacao;
            this.DataPrevista = dataprevista;
            this.StatusSolicitacaoEstoqueMovimentacaoId = statussolicitacaoestoquemovimentacaoid;
            this.Quantidade = quantidade;

        }

        public virtual int SolicitacaoEstoqueMovimentacaoId { get; protected set; }
        public virtual int EstoqueId { get; protected set; }
        public virtual bool Entrada { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual int SolicitanteId { get; protected set; }
        public virtual DateTime DataSolicitacao { get; protected set; }
        public virtual DateTime DataPrevista { get; protected set; }
        public virtual int StatusSolicitacaoEstoqueMovimentacaoId { get; protected set; }
        public virtual decimal Quantidade { get; protected set; }




    }
}
