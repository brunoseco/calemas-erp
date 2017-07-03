using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class PlanoContaAptoParaCadastroWarning : WarningSpecification<PlanoConta>
    {
        public PlanoContaAptoParaCadastroWarning(IPlanoContaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<PlanoConta>(Instance of RuleClassName,"message for user"));
        }

    }
}
