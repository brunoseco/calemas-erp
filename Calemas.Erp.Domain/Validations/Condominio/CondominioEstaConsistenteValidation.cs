using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class CondominioEstaConsistenteValidation : ValidatorSpecification<Condominio>
    {
        public CondominioEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Condominio>(Instance of RuleClassName,"message for user"));
        }

    }
}
