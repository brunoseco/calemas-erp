using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class SolicitacaoEstoque : SolicitacaoEstoqueBase
    {

        public Colaborador Solicitante { get; set; }
        public StatusSolicitacaoEstoqueMovimentacao StatusSolicitacaoEstoqueMovimentacao { get; set; }

        public SolicitacaoEstoque()
        {

        }

        public SolicitacaoEstoque(int solicitacaoestoqueid, string descricao, int solicitanteid, DateTime datasolicitacao, DateTime dataprevista, int statussolicitacaoestoquemovimentacaoid) :
            base(solicitacaoestoqueid, descricao, solicitanteid, datasolicitacao, dataprevista, statussolicitacaoestoquemovimentacaoid)
        {

        }

		public class SolicitacaoEstoqueFactory
        {
            public SolicitacaoEstoque GetDefaultInstance(dynamic data, CurrentUser user)
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

        public bool IsValid()
        {
            base._validationResult = new SolicitacaoEstoqueEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
