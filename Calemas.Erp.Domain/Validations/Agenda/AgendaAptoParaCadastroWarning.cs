using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class AgendaAptoParaCadastroWarning : WarningSpecification<Agenda>
    {
        public AgendaAptoParaCadastroWarning(IAgendaRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Agenda>(Instance of RuleClassName,"message for user"));
        }

    }
}
