using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class EstoqueMovimentacaoColaborador : EstoqueMovimentacaoColaboradorBase
    {
        public virtual Colaborador Colaborador { get; set; }
        public EstoqueMovimentacaoColaborador()
        {

        }

        public EstoqueMovimentacaoColaborador(int estoquemovimentacaocolaboradorid, int colaboradorid, bool entrada, decimal quantidade) :
            base(estoquemovimentacaocolaboradorid, colaboradorid, entrada, quantidade)
        {

        }

		public class EstoqueMovimentacaoColaboradorFactory : EstoqueMovimentacaoColaboradorFactoryBase
        {
            public EstoqueMovimentacaoColaborador GetDefaultInstance(dynamic data, CurrentUser user)
            {
                return this.GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = new EstoqueMovimentacaoColaboradorEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
