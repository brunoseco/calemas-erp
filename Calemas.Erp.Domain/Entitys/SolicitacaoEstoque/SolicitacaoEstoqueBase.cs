using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class SolicitacaoEstoqueBase : DomainBaseWithUserCreate
    {
        public SolicitacaoEstoqueBase()
        {

        }
        public SolicitacaoEstoqueBase(int solicitacaoestoqueid, string descricao, int solicitanteid, DateTime datasolicitacao, DateTime dataprevista, int statussolicitacaoestoquemovimentacaoid)
        {
            this.SolicitacaoEstoqueId = solicitacaoestoqueid;
            this.Descricao = descricao;
            this.SolicitanteId = solicitanteid;
            this.DataSolicitacao = datasolicitacao;
            this.DataPrevista = dataprevista;
            this.StatusSolicitacaoEstoqueMovimentacaoId = statussolicitacaoestoquemovimentacaoid;

        }

        public virtual int SolicitacaoEstoqueId { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual int SolicitanteId { get; protected set; }
        public virtual DateTime DataSolicitacao { get; protected set; }
        public virtual DateTime DataPrevista { get; protected set; }
        public virtual int StatusSolicitacaoEstoqueMovimentacaoId { get; protected set; }


public class SolicitacaoEstoqueFactoryBase
        {
            public virtual SolicitacaoEstoque GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new SolicitacaoEstoque(data.SolicitacaoEstoqueId,
                                        data.Descricao,
                                        data.SolicitanteId,
                                        data.DataSolicitacao,
                                        data.DataPrevista,
                                        data.StatusSolicitacaoEstoqueMovimentacaoId);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }



    }
}
