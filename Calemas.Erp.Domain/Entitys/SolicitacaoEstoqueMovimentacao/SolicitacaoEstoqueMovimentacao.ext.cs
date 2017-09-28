using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class SolicitacaoEstoqueMovimentacao : SolicitacaoEstoqueMovimentacaoBase
    {
        public Estoque Estoque { get; set; }
        public Colaborador Solicitante { get; set; }
        public StatusSolicitacaoEstoqueMovimentacao StatusSolicitacaoEstoqueMovimentacao { get; set; }
        public SolicitacaoEstoqueMovimentacao()
        {

        }

        public SolicitacaoEstoqueMovimentacao(int solicitacaoestoquemovimentacaoid, int estoqueid, bool entrada, string descricao, int solicitanteid, DateTime datasolicitacao, DateTime dataprevista, int statussolicitacaoestoquemovimentacaoid, decimal quantidade) 
            : base(solicitacaoestoquemovimentacaoid, estoqueid, entrada, descricao, solicitanteid, datasolicitacao, dataprevista, statussolicitacaoestoquemovimentacaoid, quantidade)
        {
        }

        public class SolicitacaoEstoqueMovimentacaoFactory
        {
            public SolicitacaoEstoqueMovimentacao GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new SolicitacaoEstoqueMovimentacao(data.SolicitacaoEstoqueMovimentacaoId,
                                        data.EstoqueId,
                                        data.Entrada,
                                        data.Descricao,
                                        data.SolicitanteId,
                                        data.DataSolicitacao,
                                        data.DataPrevista,
                                        data.StatusSolicitacaoEstoqueMovimentacaoId,
                                        data.Quantidade);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new SolicitacaoEstoqueMovimentacaoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
