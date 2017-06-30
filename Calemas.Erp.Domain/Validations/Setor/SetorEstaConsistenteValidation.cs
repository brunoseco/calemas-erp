using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class SetorEstaConsistenteValidation : ValidatorSpecification<Setor>
    {
        public SetorEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Setor>(Instance of RuleClassName,"message for user"));
        }

    }
}
