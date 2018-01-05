using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class StatusPagamentoAptoParaCadastroValidation : ValidatorSpecification<StatusPagamento>
    {
        public StatusPagamentoAptoParaCadastroValidation(IStatusPagamentoRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusPagamento>(Instance of RuleClassName,"message for user"));
        }

    }
}
