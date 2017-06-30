using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class PrioridadeEstaConsistenteValidation : ValidatorSpecification<Prioridade>
    {
        public PrioridadeEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Prioridade>(Instance of RuleClassName,"message for user"));
        }

    }
}
