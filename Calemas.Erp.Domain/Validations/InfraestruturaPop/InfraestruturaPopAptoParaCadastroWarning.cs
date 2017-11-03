using Common.Validation;
using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Interfaces.Repository;

namespace Calemas.Erp.Domain.Validations
{
    public class InfraestruturaPopAptoParaCadastroWarning : WarningSpecification<InfraestruturaPop>
    {
        public InfraestruturaPopAptoParaCadastroWarning(IInfraestruturaPopRepository rep)
        {
            //base.Add(Guid.NewGuid().ToString(), new Rule<InfraestruturaPop>(Instance of RuleClassName,"message for user"));
        }

    }
}
