using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class AgendaAptoParaCadastroValidation : ValidatorSpecification<Agenda>
    {
        public AgendaAptoParaCadastroValidation(IAgendaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Agenda>(Instance of RuleClassName,"message for user"));
        }

    }
}
