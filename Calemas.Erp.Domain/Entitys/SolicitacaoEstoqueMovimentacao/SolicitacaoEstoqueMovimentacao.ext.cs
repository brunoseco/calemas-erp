using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class SolicitacaoEstoqueMovimentacao : SolicitacaoEstoqueMovimentacaoBase
    {
        public Estoque Estoque { get; set; }

        public SolicitacaoEstoqueMovimentacao()
        {

        }

        public SolicitacaoEstoqueMovimentacao(int solicitacaoestoquemovimentacaoid, int solicitacaoestoqueid, int estoqueid, bool entrada, decimal quantidade) :
            base(solicitacaoestoquemovimentacaoid, solicitacaoestoqueid, estoqueid, entrada, quantidade)
        {

        }

		public class SolicitacaoEstoqueMovimentacaoFactory
        {
            public SolicitacaoEstoqueMovimentacao GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new SolicitacaoEstoqueMovimentacao(data.SolicitacaoEstoqueMovimentacaoId,
                                        data.SolicitacaoEstoqueId,
                                        data.EstoqueId,
                                        data.Entrada,
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
