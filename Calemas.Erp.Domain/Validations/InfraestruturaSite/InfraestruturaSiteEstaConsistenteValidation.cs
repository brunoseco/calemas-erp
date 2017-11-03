using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class InfraestruturaSiteEstaConsistenteValidation : ValidatorSpecification<InfraestruturaSite>
    {
        public InfraestruturaSiteEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<InfraestruturaSite>(Instance of RuleClassName,"message for user"));
        }

    }
}
