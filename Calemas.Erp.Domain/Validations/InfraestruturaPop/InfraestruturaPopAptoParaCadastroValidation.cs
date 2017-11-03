using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class InfraestruturaPopAptoParaCadastroValidation : ValidatorSpecification<InfraestruturaPop>
    {
        public InfraestruturaPopAptoParaCadastroValidation(IInfraestruturaPopRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<InfraestruturaPop>(Instance of RuleClassName,"message for user"));
        }

    }
}
