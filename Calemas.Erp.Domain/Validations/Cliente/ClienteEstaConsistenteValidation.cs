using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class ClienteEstaConsistenteValidation : ValidatorSpecification<Cliente>
    {
        public ClienteEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Cliente>(Instance of RuleClassName,"message for user"));
        }

    }
}
