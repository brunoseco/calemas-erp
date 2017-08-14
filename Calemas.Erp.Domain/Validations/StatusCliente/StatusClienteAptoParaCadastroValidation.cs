using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class StatusClienteAptoParaCadastroValidation : ValidatorSpecification<StatusCliente>
    {
        public StatusClienteAptoParaCadastroValidation(IStatusClienteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusCliente>(Instance of RuleClassName,"message for user"));
        }

    }
}
