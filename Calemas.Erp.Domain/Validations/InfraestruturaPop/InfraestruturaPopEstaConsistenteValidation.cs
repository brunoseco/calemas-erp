using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class InfraestruturaPopEstaConsistenteValidation : ValidatorSpecification<InfraestruturaPop>
    {
        public InfraestruturaPopEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<InfraestruturaPop>(Instance of RuleClassName,"message for user"));
        }

    }
}
