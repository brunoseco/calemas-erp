using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class EstoqueMovimentacaoColaborador : EstoqueMovimentacaoColaboradorBase
    {
        public virtual EstoqueMovimentacao EstoqueMovimentacao { get; set; }
        public virtual Colaborador Colaborador { get; set; }
        public EstoqueMovimentacaoColaborador()
        {

        }

        public EstoqueMovimentacaoColaborador(int estoquemovimentacaocolaboradorid, int colaboradorid, int estoquemovimentacaoid, bool entrada, decimal quantidade) :
            base(estoquemovimentacaocolaboradorid, colaboradorid, estoquemovimentacaoid, entrada, quantidade)
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
