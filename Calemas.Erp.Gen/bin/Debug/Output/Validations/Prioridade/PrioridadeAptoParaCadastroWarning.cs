using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class PrioridadeAptoParaCadastroWarning : WarningSpecification<Prioridade>
    {
        public PrioridadeAptoParaCadastroWarning(IPrioridadeRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<Prioridade>(Instance of RuleClassName,"message for user"));
        }

    }
}
