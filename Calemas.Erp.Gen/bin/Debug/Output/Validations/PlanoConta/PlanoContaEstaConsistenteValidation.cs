using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class PlanoContaEstaConsistenteValidation : ValidatorSpecification<PlanoConta>
    {
        public PlanoContaEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<PlanoConta>(Instance of RuleClassName,"message for user"));
        }

    }
}
