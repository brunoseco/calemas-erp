using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class StatusPagamento : StatusPagamentoBase
    {

        public StatusPagamento()
        {

        }

        public StatusPagamento(int statuspagamentoid, string nome) :
            base(statuspagamentoid, nome)
        {

        }

		public class StatusPagamentoFactory : StatusPagamentoFactoryBase
        {
            public StatusPagamento GetDefaultInstance(dynamic data, CurrentUser user)
            {
                return this.GetDefaultInstanceBase(data, user);
            }
        }

        public bool IsValid()
        {
            base._validationResult = new StatusPagamentoEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
