using Common.Validation;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Domain.Validations
{
    public class AgendaEstaConsistenteValidation : ValidatorSpecification<Agenda>
    {
        public AgendaEstaConsistenteValidation()
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Agenda>(Instance of RuleClassName,"message for user"));
        }

    }
}
