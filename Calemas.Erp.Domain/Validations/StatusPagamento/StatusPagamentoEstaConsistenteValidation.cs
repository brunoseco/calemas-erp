using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class StatusPagamentoEstaConsistenteValidation : ValidatorSpecification<StatusPagamento>
    {
        public StatusPagamentoEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusPagamento>(Instance of RuleClassName,"message for user"));
        }

    }
}
