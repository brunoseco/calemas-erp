using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class StatusSolicitacaoEstoqueMovimentacao : StatusSolicitacaoEstoqueMovimentacaoBase
    {

        public StatusSolicitacaoEstoqueMovimentacao()
        {

        }

        public StatusSolicitacaoEstoqueMovimentacao(int statussolicitacaoestoquemovimentacaoid, string nome) :
            base(statussolicitacaoestoquemovimentacaoid, nome)
        {

        }

		public class StatusSolicitacaoEstoqueMovimentacaoFactory
        {
            public StatusSolicitacaoEstoqueMovimentacao GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new StatusSolicitacaoEstoqueMovimentacao(data.StatusSolicitacaoEstoqueMovimentacaoId,
                                        data.Nome);



				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new StatusSolicitacaoEstoqueMovimentacaoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
