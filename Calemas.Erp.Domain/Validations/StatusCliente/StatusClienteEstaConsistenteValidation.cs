using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class StatusClienteEstaConsistenteValidation : ValidatorSpecification<StatusCliente>
    {
        public StatusClienteEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<StatusCliente>(Instance of RuleClassName,"message for user"));
        }

    }
}
