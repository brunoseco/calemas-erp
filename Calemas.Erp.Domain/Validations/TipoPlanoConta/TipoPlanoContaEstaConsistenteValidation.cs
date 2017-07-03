using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class TipoPlanoContaEstaConsistenteValidation : ValidatorSpecification<TipoPlanoConta>
    {
        public TipoPlanoContaEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<TipoPlanoConta>(Instance of RuleClassName,"message for user"));
        }

    }
}
