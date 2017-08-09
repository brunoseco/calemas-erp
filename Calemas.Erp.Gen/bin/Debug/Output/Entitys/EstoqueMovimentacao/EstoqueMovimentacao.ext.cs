using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class EstoqueMovimentacao : EstoqueMovimentacaoBase
    {

        public EstoqueMovimentacao()
        {

        }

        public EstoqueMovimentacao(int estoquemovimentacaoid, int estoqueid, bool entrada, string descricao, decimal quantidade, int responsavelid) :
            base(estoquemovimentacaoid, estoqueid, entrada, descricao, quantidade, responsavelid)
        {

        }

		public class EstoqueMovimentacaoFactory
        {
            public EstoqueMovimentacao GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new EstoqueMovimentacao(data.EstoqueMovimentacaoId,
                                        data.EstoqueId,
                                        data.Entrada,
                                        data.Descricao,
                                        data.Quantidade,
                                        data.ResponsavelId);



				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new EstoqueMovimentacaoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
