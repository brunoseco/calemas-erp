using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class AgendaColaboradorAptoParaCadastroWarning : WarningSpecification<AgendaColaborador>
    {
        public AgendaColaboradorAptoParaCadastroWarning(IAgendaColaboradorRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<AgendaColaborador>(Instance of RuleClassName,"message for user"));
        }

    }
}
