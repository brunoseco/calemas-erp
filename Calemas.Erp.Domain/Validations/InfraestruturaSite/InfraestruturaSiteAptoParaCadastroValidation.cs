using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class InfraestruturaSiteAptoParaCadastroValidation : ValidatorSpecification<InfraestruturaSite>
    {
        public InfraestruturaSiteAptoParaCadastroValidation(IInfraestruturaSiteRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<InfraestruturaSite>(Instance of RuleClassName,"message for user"));
        }

    }
}
