using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class CondominioAptoParaCadastroValidation : ValidatorSpecification<Condominio>
    {
        public CondominioAptoParaCadastroValidation(ICondominioRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Condominio>(Instance of RuleClassName,"message for user"));
        }

    }
}
