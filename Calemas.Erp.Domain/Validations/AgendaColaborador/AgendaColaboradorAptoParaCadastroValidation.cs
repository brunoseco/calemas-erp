using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class AgendaColaboradorAptoParaCadastroValidation : ValidatorSpecification<AgendaColaborador>
    {
        public AgendaColaboradorAptoParaCadastroValidation(IAgendaColaboradorRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<AgendaColaborador>(Instance of RuleClassName,"message for user"));
        }

    }
}
