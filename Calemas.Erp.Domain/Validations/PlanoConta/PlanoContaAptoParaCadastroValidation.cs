using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class PlanoContaAptoParaCadastroValidation : ValidatorSpecification<PlanoConta>
    {
        public PlanoContaAptoParaCadastroValidation(IPlanoContaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<PlanoConta>(Instance of RuleClassName,"message for user"));
        }

    }
}
