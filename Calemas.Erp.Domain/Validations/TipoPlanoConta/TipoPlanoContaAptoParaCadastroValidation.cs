using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class TipoPlanoContaAptoParaCadastroValidation : ValidatorSpecification<TipoPlanoConta>
    {
        public TipoPlanoContaAptoParaCadastroValidation(ITipoPlanoContaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoPlanoConta>(Instance of RuleClassName,"message for user"));
        }

    }
}
