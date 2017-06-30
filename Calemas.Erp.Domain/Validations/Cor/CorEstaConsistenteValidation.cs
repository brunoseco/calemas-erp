using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class CorEstaConsistenteValidation : ValidatorSpecification<Cor>
    {
        public CorEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Cor>(Instance of RuleClassName,"message for user"));
        }

    }
}
